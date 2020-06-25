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
    public class MacRepository : IMac
    {
        private Smart_Api_DBContext _context;
        private IMemoryCache _cache;

        public MacRepository(Smart_Api_DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<Mac> Add(Mac mac)
        {
            await _context.Mac.AddAsync(mac);
            await _context.SaveChangesAsync();

            return mac;
        }

        public async Task<int> Count()
        {
            return await _context.Mac.CountAsync();
        }

        public async Task<Mac> Find(int id)
        {
            return await _context.Mac.SingleOrDefaultAsync(c => c.MacId == id);
        }

        public IEnumerable<Mac> GetAll()
        {
            return _context.Mac.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Mac.AnyAsync(c => c.MacId == id);
        }

        public async Task<Mac> Remove(int id)
        {
            var Mac = await _context.Mac.SingleAsync(c => c.MacId == id);
            _context.Mac.Remove(Mac);
            await _context.SaveChangesAsync();
            return Mac;
        }

        public async Task<Mac> Update(Mac mac)
        {
            _context.Update(mac);
            await _context.SaveChangesAsync();
            return mac;
        }
    }
}
