using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repo
{
    public interface IGenericRepository<T> where T : class 
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        void DeleteById(int id);
        void Save();
    }
}
