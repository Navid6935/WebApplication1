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
    public class AppUpdateRepository : IAppUpdate
    {
        private Smart_Api_DBContext _context;
        private IMemoryCache _cache;

        public AppUpdateRepository(Smart_Api_DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<AppUpdate> Add(AppUpdate appupdate)
        {
            await _context.AppUpdate.AddAsync(appupdate);
            await _context.SaveChangesAsync();

            return appupdate;
        }

        public async Task<int> Count()
        {
            return await _context.AppUpdate.CountAsync();
        }

        public async Task<AppUpdate> Find(int id)
        {
            return await _context.AppUpdate.SingleOrDefaultAsync(c => c.AppUpdateId == id);
        }

        public IEnumerable<AppUpdate> GetAll()
        {
            return _context.AppUpdate.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.AppUpdate.AnyAsync(c => c.AppUpdateId == id);
        }

        public async Task<AppUpdate> Remove(int id)
        {
            var appUpdate = await _context.AppUpdate.SingleAsync(c => c.AppUpdateId == id);
            _context.AppUpdate.Remove(appUpdate);
            await _context.SaveChangesAsync();
            return appUpdate;
        }

        public async Task<AppUpdate> Update(AppUpdate appupdate)
        {
            _context.Update(appupdate);
            await _context.SaveChangesAsync();
            return appupdate;
        }
    }
}
