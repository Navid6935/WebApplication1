using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    interface IStoredSerial
    {
                IEnumerable<StoredSerials> GetAll();
        Task<StoredSerials> Add(StoredSerials storedSerial);
        Task<StoredSerials> Find(int id);
        Task<StoredSerials> Update(StoredSerials storedSerial);
        Task<StoredSerials> Remove(int id);
        Task<bool> IsExists(int id);
        Task<int> Count();
    }
}
