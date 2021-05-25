using System;
using System.Collections.Generic;
using teste_comadre.Models;

namespace teste_comadre.Respositories
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        IEnumerable<Transaction> GetAllByUser(int userId);



    }
}