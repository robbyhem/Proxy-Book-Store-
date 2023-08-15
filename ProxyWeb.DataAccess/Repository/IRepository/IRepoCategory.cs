using ProxyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyWeb.DataAccess.Repository.IRepository
{
    public interface IRepoCategory : IRepo<Category>
    {
        void Update(Category category);
    }
}
