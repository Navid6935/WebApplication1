using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    interface IAppDevices
    {
            IEnumerable<AppDevices> GetAll();
            Task<AppDevices> Add(AppDevices appdevice);
            Task<AppDevices> Find(int id);
            Task<AppDevices> Update(AppDevices appdevice);
            Task<AppDevices> Remove(int id);
            Task<bool> IsExists(int id);
            Task<int> Count();
        
    }
}
