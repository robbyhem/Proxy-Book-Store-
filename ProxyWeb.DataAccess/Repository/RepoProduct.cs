using ProxyWeb.DataAccess.Data;
using ProxyWeb.DataAccess.Repository.IRepository;
using ProxyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyWeb.DataAccess.Repository
{
    public class RepoProduct : Repo<Product>, IRepoProduct
    {
        private readonly ApplicationDbContext _context;
        
        public RepoProduct(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product); ;
        }
    }
}
