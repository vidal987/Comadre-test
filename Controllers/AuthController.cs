using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using teste_comadre.Models;
using teste_comadre.Services;
using teste_comadre.ViewModels;

namespace teste_comadre.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public AuthController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserPostViewModel userPostViewModel)
        {
            //mapear 
            var user = mapper.Map<User>(userPostViewModel);

            // Recupera o usuário
            var isValidUser =  await userService.Validate(user);

            // Verifica se o usuário existe
            if (isValidUser == false)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            user = await userService.GetByLogin(user.Login);

            if (user == null)
            {
                return BadRequest(new { message = "Algo de errado aconteceu." });
            }

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}