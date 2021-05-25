using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace teste_comadre.Respositories
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> Get();
        T GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);

    }
}