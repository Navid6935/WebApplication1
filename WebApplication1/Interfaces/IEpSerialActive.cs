using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    interface IEpSerialActive
    {
        IEnumerable<EspSerialActive> GetAll();
        Task<EspSerialActive> Add(EspSerialActive espSerialActive);
        Task<EspSerialActive> Find(int id);
        Task<EspSerialActive> Update(EspSerialActive espSerialActive);
        Task<EspSerialActive> Remove(int id);
        Task<bool> IsExists(int id);
        Task<int> Count();
    }
}
