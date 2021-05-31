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

            //TODO : Passar ID da conta como TOken
            //OBTER ID DO USUARIO LOGADO DE ACORDO COM O TOKEN ID
            // Int32.TryParse (HttpContext.User.Identity.Name, out var id );

            var currentUser = HttpContext.User;
            int id1, id2;
            string name;

            if (currentUser.HasClaim(c => c.Type == "role"))    
            {    
                id1 = Int32.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "role").Value);        
            }   
            if (currentUser.HasClaim(c => c.Type == "Role"))    
            {    
                id2 = Int32.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "role").Value);        
            }  
            if (currentUser.HasClaim(c => c.Type == "Name"))    
            {    
                name = currentUser.Claims.FirstOrDefault(c => c.Type == "role").Value;        
            }  

            // Int32.TryParse(currentUser.Claims.FirstOrDefault(c => c.Type == "role").Value, );    
            // Int32.TryParse(currentUser.Claims.FirstOrDefault(c => c.Type == "Role").Value, out var id2);    
            
            // var login = currentUser.Claims.FirstOrDefault(c => c.Type == "Name").Value;

            if(0 == 0)
                return NotFound();
            //buscar saldo inicial e aplicar transações para descobrir o saldo atual
            var balance = await accountService.GetBalance(0);

            //retornar saldo atual!
            return Ok(balance);
        }
        
    }
}