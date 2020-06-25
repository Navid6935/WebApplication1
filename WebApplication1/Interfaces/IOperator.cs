using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IOperator
    {
        IEnumerable<Operator> GetAll();
        Task<Operator> Add(Operator operaator);
        Task<Operator> Find(int id);
        Task<Operator> Update(Operator operaator);
        Task<Operator> Remove(int id);
        Task<bool> IsExists(int id);
        Task<int> Count();
    }
}
