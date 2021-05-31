using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using teste_comadre.Respositories;
using teste_comadre.ViewModels;
using teste_comadre.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace teste_comadre.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IMapper mapper;

        public TransactionController(ITransactionRepository transactionRepository, IMapper mapper)
        {
            this.transactionRepository = transactionRepository;
            this.mapper = mapper;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetByDateRange([FromQuery] int currentUser, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate )
        {
            var transactions = transactionRepository.GetAllByUser(currentUser);

            var transactionsInPeriod = transactions.Where(t => t.CreateDate >= startDate && t.CreateDate <= endDate );
            
            return Ok(transactionsInPeriod);
        }
        //POST, DELETE
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<bool>> Post([FromBody] TransactionPostViewModel transactionPostViewModel)
        {
            var account = mapper.Map<Transaction>(transactionPostViewModel);

            var inserted = transactionRepository.Add(account);
            
            //TODO: Colocar status code apropriado 406 || 409

            return Ok(inserted);
        }
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromQuery] int id)
        {
            var delete = transactionRepository.Delete(id);

            return delete ? Ok(delete) : NotFound();
        }



    }
}