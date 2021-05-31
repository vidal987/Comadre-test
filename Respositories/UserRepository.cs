using System.Linq;
using System.Threading.Tasks;
using teste_comadre.Data;
using teste_comadre.Models;

namespace teste_comadre.Respositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext) {}

        public bool Exists(string login, string password)
        {
            var user = dataContext.User.FirstOrDefault(u => u.Login == login && u.Password == password);

            return user != null;
        }

        public User? GetByLogin(string userLogin)
        {
            var user = dataContext.User.FirstOrDefault(u => u.Login == userLogin);

            return user;
        }
    }
}