using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    interface ICategory
    {
        IEnumerable<Category> GetAll();
        Task<Category> Add(Category category);
        Task<Category> Find(int id);
        Task<Category> Update(Category category);
        Task<Category> Remove(int id);
        Task<bool> IsExists(int id);
        Task<int> Count();
    }
}
