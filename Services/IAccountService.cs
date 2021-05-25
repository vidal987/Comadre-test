using System;
using System.Threading.Tasks;
using teste_comadre.Models;

namespace teste_comadre.Services
{
    public interface IAccountService
    {
        Task<bool> Create(Account account);

        Task<decimal> GetBalance(int id);
    }
}