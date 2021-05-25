using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using teste_comadre.Models;
using teste_comadre.Respositories;
using teste_comadre.Services;
using teste_comadre.ViewModels;

namespace teste_comadre.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IMapper mapper;
        public AccountController(IAccountService accountService, IMapper mapper)
        {
            this.accountService = accountService;

            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post ([FromBody] AccountPostViewModel accountPostViewModel)
        {
            //MAPEAR VIEWMODEL PARA MODEL 
            //TODO: ALTERAR TIPO DE RETURNO PARA ACTION RESULT<T>

            var account = mapper.Map<Account>(accountPostViewModel);

            //CHAMAR SERVIÇO COM MODEL
            var inserted = await accountService.Create(account);
            
            //RETORNAR STATUS CODE APROPRIADAMENTE
            return Ok(inserted);
        }

        [HttpGet]
        public async Task<ActionResult<bool>> Get([FromServices] IBaseRepository<Account> accountRepository ) 
        {
            var users = accountRepository.Get();

            return Ok(users);
        }


        
    }
}