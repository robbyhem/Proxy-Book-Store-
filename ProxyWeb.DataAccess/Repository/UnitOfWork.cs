using Microsoft.EntityFrameworkCore;
using ProxyWeb.DataAccess.Data;
using ProxyWeb.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyWeb.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public IRepoCategory Category { get; private set; }
        public IRepoProduct Product { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context= context;
            Category = new RepoCategory(_context);
            Product = new RepoProduct(_context);

        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
