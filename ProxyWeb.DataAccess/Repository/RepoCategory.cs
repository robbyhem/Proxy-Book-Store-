using ProxyWeb.DataAccess.Data;
using ProxyWeb.DataAccess.Repository.IRepository;
using ProxyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProxyWeb.DataAccess.Repository
{
    public class RepoCategory : Repo<Category>, IRepoCategory
    {
        private readonly ApplicationDbContext _context;
        
        public RepoCategory(ApplicationDbContext context) : base(context)
        {
            _context= context;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
