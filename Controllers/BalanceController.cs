using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using teste_comadre.Services;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;

namespace teste_comadre.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BalanceController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<decimal>> Get ([FromServices] IAccountService accountService)
        {
            var currentUser = HttpContext.User;
            int.TryParse(currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value, out var id);    
            
            if(id == 0)
                return NotFound();
            
            //buscar saldo inicial e aplicar transações para descobrir o saldo atual
            var balance = await accountService.GetBalance(id);

            //retornar saldo atual!
            return Ok(balance);
        }
        
    }
}