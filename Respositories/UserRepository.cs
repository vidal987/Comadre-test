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
            var user = dataContext.User.Where(u => u.Login == login && u.Password == password).FirstOrDefault();

            return user != null;
        }
    }
}