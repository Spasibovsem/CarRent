using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data.Repo
{
    public interface IGenericRepository<T> where T : class 
    {
        IQueryable<T> FindAll();
        T FindById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        void DeleteById(int id);
    }
}
