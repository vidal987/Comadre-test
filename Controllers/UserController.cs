using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using teste_comadre.Models;
using teste_comadre.Services;
using teste_comadre.ViewModels;

namespace teste_comadre.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> Post([FromBody] UserPostViewModel userPostViewModel )
        { 
            //Todo: verificar se é possivel inserir reposotrio base direto na controller
            //mapear entidade
            var user = mapper.Map<User>(userPostViewModel);
            //criar o usuario 
            var isInserted  =  await userService.Create(user); 
            //retornar status code
            return Ok(isInserted);
        }


    }
}