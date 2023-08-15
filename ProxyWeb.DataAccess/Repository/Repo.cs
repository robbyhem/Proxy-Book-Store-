using Microsoft.EntityFrameworkCore;
using ProxyWeb.DataAccess.Data;
using ProxyWeb.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProxyWeb.DataAccess.Repository
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> DbSet { get; set; }

        public Repo(ApplicationDbContext context)
        {
            _context= context;
            this.DbSet = _context.Set<T>(); //<= _context.Categories = DbSet
        }
        
        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = DbSet;
            return query.ToList();
        }
    }
}
