using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    interface IAppUpdate
    {            IEnumerable<AppUpdate> GetAll();
            Task<AppUpdate> Add(AppUpdate appupdate);
            Task<AppUpdate> Find(int id);
            Task<AppUpdate> Update(AppUpdate appupdate);
            Task<AppUpdate> Remove(int id);
            Task<bool> IsExists(int id);
            Task<int> Count();
    }
}
