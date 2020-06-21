using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ITestTable
    {
        IEnumerable<TestTable> GetAll();
        Task<TestTable> Add(TestTable testtable);
        Task<TestTable> Find(int id);
        Task<TestTable> Update(TestTable testtable);
        Task<TestTable> Remove(int id);
        Task<bool> IsExists(int id);
        Task<int> Count();
    }
}
