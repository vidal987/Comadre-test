using System;
using System.Threading.Tasks;
using teste_comadre.Models;

namespace teste_comadre.Services
{
    public interface IUserService
    {
        Task<bool> Create(User user);
        Task<bool> Validate(User user);
    }
}