using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class CategoriesRepository : ICategory
    {
        private Smart_Api_DBContext _context;
        private IMemoryCache _cache;

        public CategoriesRepository(Smart_Api_DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<Category> Add(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<int> Count()
        {
            return await _context.Category.CountAsync();
        }

        public async Task<Category> Find(int id)
        {
            return await _context.Category.SingleOrDefaultAsync(c => c.CatId == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Category.AnyAsync(c => c.CatId == id);
        }

        public async Task<Category> Remove(int id)
        {
            var category = await _context.Category.SingleAsync(c => c.CatId == id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
