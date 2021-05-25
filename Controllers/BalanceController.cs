using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using teste_comadre.Services;

namespace teste_comadre.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BalanceController : ControllerBase
    {
     
        [HttpGet]
        public async Task<ActionResult<decimal>> Get ([FromQuery] int id, [FromServices] IAccountService accountService)
        {
            //OBTER ID DO USUARIO LOGADO DE ACORDO COM O TOKEN ID
            
            //buscar saldo inicial e aplicar transações para descobrir o saldo atual
            var balance = await accountService.GetBalance(id);
            

            //retornar saldo atual!
            return Ok(balance);
        }
        
    }
}