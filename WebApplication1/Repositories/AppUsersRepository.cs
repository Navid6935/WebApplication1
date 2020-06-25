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
    public class AppUsersRepository : IAppUsers
    {
        private Smart_Api_DBContext _context;
        private IMemoryCache _cache;

        public AppUsersRepository(Smart_Api_DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<AppUsers> Add(AppUsers appusers)
        {
            await _context.AppUsers.AddAsync(appusers);
            await _context.SaveChangesAsync();

            return appusers;
        }

        public async Task<int> Count()
        {
            return await _context.AppUsers.CountAsync();
        }

        public async Task<AppUsers> Find(int id)
        {
            return await _context.AppUsers.SingleOrDefaultAsync(c => c.UserId == id);
        }

        public IEnumerable<AppUsers> GetAll()
        {
            return _context.AppUsers.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.AppUsers.AnyAsync(c => c.UserId == id);
        }

        public async Task<AppUsers> Remove(int id)
        {
            var appUsers = await _context.AppUsers.SingleAsync(c => c.UserId == id);
            _context.AppUsers.Remove(appUsers);
            await _context.SaveChangesAsync();
            return appUsers;
        }

        public async Task<AppUsers> Update(AppUsers appusers)
        {
            _context.Update(appusers);
            await _context.SaveChangesAsync();
            return appusers;
        }
    }
}
