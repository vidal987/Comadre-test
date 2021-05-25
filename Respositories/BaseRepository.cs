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
            return dataContext.Set<T>().Where(x => x.Id == id).FirstOrDefault();

        }

        public bool Add(T entity)
        {
            dataContext.Set<T>().Add(entity);

            dataContext.SaveChanges();

            return  dataContext.SaveChanges() == 1;
        }

        public bool Update(T entity)
        {
            dataContext.Entry(entity).State = EntityState.Modified;
            dataContext.Set<T>().Update(entity);

            dataContext.SaveChanges();
            
            return  dataContext.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            var entity = dataContext.Set<T>().Where(x => x.Id == id).FirstOrDefault();

            dataContext.Set<T>().Remove(entity);

            dataContext.SaveChanges();

            return  dataContext.SaveChanges() == 1;
        }


    }
}