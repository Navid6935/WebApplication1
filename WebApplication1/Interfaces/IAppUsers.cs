using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
   public interface IAppUsers
    {
        IEnumerable<AppUsers> GetAll();
        Task<AppUsers> Add(AppUsers appusers);
        Task<AppUsers> Find(int id);
        Task<AppUsers> Update(AppUsers appusers);
        Task<AppUsers> Remove(int id);
        Task<bool> IsExists(int id);
        Task<int> Count();
    }
}
