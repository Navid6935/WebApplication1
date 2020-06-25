using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class SerialRepository : ISerial
    {
        private Smart_Api_DBContext _context;
        private IMemoryCache _cache;

        public SerialRepository(Smart_Api_DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<Serial> Add(Serial serial)
        {
            await _context.Serial.AddAsync(serial);
            await _context.SaveChangesAsync();

            return serial;
        }

        public async Task<int> Count()
        {
            return await _context.Serial.CountAsync();
        }

        public async Task<Serial> Find(int id)
        {
            return await _context.Serial.SingleOrDefaultAsync(c => c.SerialId == id);
        }

        public IEnumerable<Serial> GetAll()
        {
            return _context.Serial.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Serial.AnyAsync(c => c.SerialId == id);
        }

        public async Task<Serial> Remove(int id)
        {
            var serial = await _context.Serial.SingleAsync(c => c.SerialId == id);
            _context.Serial.Remove(serial);
            await _context.SaveChangesAsync();
            return serial;
        }

        public async Task<Serial> Update(Serial serial)
        {
            _context.Update(serial);
            await _context.SaveChangesAsync();
            return serial;
        }
    }
}
