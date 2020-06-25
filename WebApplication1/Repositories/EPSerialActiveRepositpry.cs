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
    public class EPSerialActiveRepositpry : IEpSerialActive
    {
        private Smart_Api_DBContext _context;
        private IMemoryCache _cache;

        public EPSerialActiveRepositpry(Smart_Api_DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<EspSerialActive> Add(EspSerialActive espSerialActive)
        {
            await _context.EspSerialActive.AddAsync(espSerialActive);
            await _context.SaveChangesAsync();

            return espSerialActive;
        }

        public async Task<int> Count()
        {
            return await _context.EspSerialActive.CountAsync();
        }

        public async Task<EspSerialActive> Find(int id)
        {
            return await _context.EspSerialActive.SingleOrDefaultAsync(c => c.EsId == id);
        }

        public IEnumerable<EspSerialActive> GetAll()
        {
            return _context.EspSerialActive.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.EspSerialActive.AnyAsync(c => c.EsId == id);
        }

        public async Task<EspSerialActive> Remove(int id)
        {
            var espSerialActive = await _context.EspSerialActive.SingleAsync(c => c.EsId == id);
            _context.EspSerialActive.Remove(espSerialActive);
            await _context.SaveChangesAsync();
            return espSerialActive;
        }

        public async Task<EspSerialActive> Update(EspSerialActive espSerialActive)
        {
            _context.Update(espSerialActive);
            await _context.SaveChangesAsync();
            return espSerialActive;
        }
    }
}
