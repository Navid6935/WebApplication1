using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    interface ISerial
    {
        IEnumerable<Serial> GetAll();
        Task<Serial> Add(Serial serial);
        Task<Serial> Find(int id);
        Task<Serial> Update(Serial serial);
        Task<Serial> Remove(int id);
        Task<bool> IsExists(int id);
        Task<int> Count();
    }
}
