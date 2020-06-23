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
    public class AppDevicesRepositories : IAppDevices
    {
        private Smart_Api_DBContext _context;
        private IMemoryCache _cache;

        public AppDevicesRepositories(Smart_Api_DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<AppDevices> Add(AppDevices appdevice)
        {
            await _context.AppDevices.AddAsync(appdevice);
            await _context.SaveChangesAsync();

            return appdevice;
        }

        public async Task<int> Count()
        {
            return await _context.AppDevices.CountAsync();
        }

        public async Task<AppDevices> Find(int id)
        {
            return await _context.AppDevices.SingleOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<AppDevices> GetAll()
        {
            return _context.AppDevices.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.AppDevices.AnyAsync(c => c.DeviceId == id);
        }

        public async Task<AppDevices> Remove(int id)
        {
            var appdevices = await _context.AppDevices.SingleAsync(c => c.DeviceId == id);
            _context.AppDevices.Remove(appdevices);
            await _context.SaveChangesAsync();
            return appdevices;
        }

        public async Task<AppDevices> Update(AppDevices appdevice)
        {
            _context.Update(appdevice);
            await _context.SaveChangesAsync();
            return appdevice;
        }
    }
}
