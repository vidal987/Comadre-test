using System;
using System.Threading.Tasks;
using teste_comadre.Models;

namespace teste_comadre.Respositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool Exists(string login, string password);
        User? GetByLogin(string userLogin);
    }
}