using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class TestTableRepository : ITestTable
    {
        private Smart_Api_DBContext _context;
        private IMemoryCache _cache;

        public TestTableRepository(Smart_Api_DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<TestTable> Add(TestTable testtable)
        {

            await _context.TestTable.AddAsync(testtable);
            await _context.SaveChangesAsync();

            return testtable;

        }
        public void NewAdd()
        {
            var id = 1;
            var name = "asdasdasdsad";
            var cacheOption = new MemoryCacheEntryOptions()
    .SetSlidingExpiration(TimeSpan.FromDays(500));
            for (int i = 0; i < 200000; i++)
            {

                _cache.Set(id, name, cacheOption);
            }
            //for (int i = 0; i < 200000; i++)
            //{
            //    TestTable testtable = new TestTable();
            //    testtable.Name = "asdasd";
            //    _context.TestTable.AddAsync(testtable);
            //    _context.SaveChangesAsync();
            //    Thread.Sleep(200);
            //}



        }
        public async Task<int> Count()
        {
            return await _context.TestTable.CountAsync();
        }

        public async Task<TestTable> Find(int id)
        {
            //if (cacheTestTable != null)
            //{
            //    return cacheTestTable;
            //}
            //else
            //{
            //var testtable = await _context.TestTable.SingleOrDefaultAsync(c => c.Id == id);

            var cacheTestTable = _cache.Get<TestTable>(id);

            return cacheTestTable;

            //}
            //return await _context.TestTable.SingleOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<TestTable> GetAll()
        {
            Thread a = new Thread(new ThreadStart(NewAdd));
            a.Start();
            a.Join();
            return _context.TestTable.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.TestTable.AnyAsync(c => c.Id == id);
        }

        public async Task<TestTable> Remove(int id)
        {
            var testtable = await _context.TestTable.SingleAsync(c => c.Id == id);
            _context.TestTable.Remove(testtable);
            await _context.SaveChangesAsync();
            return testtable;
        }

        public async Task<TestTable> Update(TestTable testtable)
        {
            _context.Update(testtable);
            await _context.SaveChangesAsync();
            return testtable;
        }
    }
}
