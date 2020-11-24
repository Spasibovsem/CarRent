using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Data.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CarRentContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(CarRentContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> FindAll()
        {
            return _dbSet.ToList();
        }
        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Insert(T obj)
        {
            _dbSet.Add(obj);
        }
        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(T obj)
        {
            _dbSet.Remove(obj);
        }
        public void DeleteById(int id)
        {
            T obj = _dbSet.Find(id);
            _dbSet.Remove(obj);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
