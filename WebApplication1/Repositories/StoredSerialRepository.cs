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
    public class StoredSerialRepository : IStoredSerial
    {
        private Smart_Api_DBContext _context;
        private IMemoryCache _cache;

        public StoredSerialRepository(Smart_Api_DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<StoredSerials> Add(StoredSerials storedSerial)
        {
            await _context.StoredSerials.AddAsync(storedSerial);
            await _context.SaveChangesAsync();

            return storedSerial;
        }

        public async Task<int> Count()
        {
            return await _context.StoredSerials.CountAsync();
        }

        public async Task<StoredSerials> Find(int id)
        {
            return await _context.StoredSerials.SingleOrDefaultAsync(c => c.StoredSerialsId == id);
        }

        public IEnumerable<StoredSerials> GetAll()
        {
            return _context.StoredSerials.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.StoredSerials.AnyAsync(c => c.StoredSerialsId == id);
        }

        public async Task<StoredSerials> Remove(int id)
        {
            var storedSerial = await _context.StoredSerials.SingleAsync(c => c.StoredSerialsId == id);
            _context.StoredSerials.Remove(storedSerial);
            await _context.SaveChangesAsync();
            return storedSerial;
        }

        public async Task<StoredSerials> Update(StoredSerials storedSerial)
        {
            _context.Update(storedSerial);
            await _context.SaveChangesAsync();
            return storedSerial;
        }
    }
}
