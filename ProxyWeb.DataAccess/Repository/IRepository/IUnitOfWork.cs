using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyWeb.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IRepoCategory Category { get; }
        
        void Save();
    }
}
