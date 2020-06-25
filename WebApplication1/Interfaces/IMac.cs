using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    interface IMac
    {
        IEnumerable<Mac> GetAll();
        Task<Mac> Add(Mac mac);
        Task<Mac> Find(int id);
        Task<Mac> Update(Mac mac);
        Task<Mac> Remove(int id);
        Task<bool> IsExists(int id);
        Task<int> Count();
    }
}
