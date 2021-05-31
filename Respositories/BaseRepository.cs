using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using teste_comadre.Data;
using teste_comadre.Models;

namespace teste_comadre.Respositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext dataContext;

        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<T> Get()
        {
            return  dataContext.Set<T>().AsNoTracking().Select(x => x).AsEnumerable<T>();
        }

        public T GetById(int id)
        {
            return dataContext.Set<T>().FirstOrDefault(x => x.Id == id);

        }

        public bool Add(T entity)
        {
            dataContext.Set<T>().Add(entity);

            return dataContext.SaveChanges() == 1;
        }

        public bool Update(T entity)
        {
            dataContext.Entry(entity).State = EntityState.Modified;
            dataContext.Set<T>().Update(entity);

            return dataContext.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            var entity = dataContext.Set<T>().FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return false;
            }

            dataContext.Set<T>().Remove(entity);

            return dataContext.SaveChanges() == 1;
        }


    }
}