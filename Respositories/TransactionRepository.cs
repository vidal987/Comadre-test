using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using teste_comadre.Data;
using teste_comadre.Models;
using System.Linq;

namespace teste_comadre.Respositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        private readonly DbSet<Transaction> transactions;
        public TransactionRepository(DataContext dataContext) : base(dataContext) 
        {
            this.transactions = dataContext.Transaction;
        }

        public IEnumerable<Transaction> GetAllByUser(int userId)
        {   
            var tran = transactions.Where(t => t.IdSender == userId || t.IdReceiver == userId);

            return tran;  
        }

        public new bool Delete(int id)
        {
            var transaction = transactions.Where(x => x.Id == id).FirstOrDefault();

            if(transaction.Id == 0)
                return false;
                
            transaction.IsCanceled = true;

            transactions.Update(transaction);

            return dataContext.SaveChanges() == 1;

        }        
    }
}