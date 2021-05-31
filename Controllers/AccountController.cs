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
    public class AccountController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountService;

        public AccountController(IMapper mapper, IAccountService accountService)
        {
            this.mapper = mapper;
            this.accountService = accountService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<bool>> Post([FromQuery] int userId, [FromBody] AccountPostViewModel accountPostViewModel)
        {
            //mapear account
            var account = mapper.Map<Account>(accountPostViewModel);

            //criar account
            var createdAccount = await accountService.Create(userId, account);

            //return
            return Ok(createdAccount);
        }
    }
}