using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using teste_comadre.Models;
using teste_comadre.Respositories;

namespace teste_comadre.Services
{
    public class UserService : IUserService
    {
        // private readonly IBaseRepository<User> userRepository;
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> Create(User user)
        {
            //CRIAR UM USUARIO
            var userInserted = userRepository.Add(user);

            return userInserted;
        }

        public async Task<bool> Validate(User user)
        {
            var exists = userRepository.Exists(user.Login, user.Password);

            return exists;
        }

        public async Task<User?> GetByLogin(string userLogin)
        {
            return userRepository.GetByLogin(userLogin);
        }
    }
}