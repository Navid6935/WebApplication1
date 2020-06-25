using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly IDistributedCache _distributedCache;

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
        public void NewCache(int id)
        {
            //var cacheTestTable = _cache.Get<TestTable>(id);
            //if (cacheTestTable != null)
            //{
            //}
            //else
            //{
            //    var testtable =  _context.TestTable.tolis();
            //    var cacheOption = new MemoryCacheEntryOptions()
            //        .SetSlidingExpiration(TimeSpan.FromSeconds(60));
            //    _cache.Set(testtable.Id, testtable, cacheOption);
            //    return testtable;

            //}

        }
        public void NewAdd()


        {


            var cacheOption = new MemoryCacheEntryOptions()
    .SetSlidingExpiration(TimeSpan.FromDays(500));
            //for (int i = 0; i < 200000; i++)
            //{
            //    _cache.Set(id, name, cacheOption);
            //}
            //DataTable dt = new DataTable("NewTable");
            ////dt.Columns.Add("Name", typeof(string));
            //var list = _context.TestTable.ToList();

            TestTable testtable = new TestTable();
            //for (int i = 256000; i < 261000; i++)
            //{
            //    testtable.Name = "asdffff"+i;
            //    testtable.Id = i;
            //    _context.TestTable.AddRange(testtable);
            //    _context.SaveChanges();
            //}
            //for (int i = 0; i < 200000; i++)
            //{

            //    //dt.Clear();
            //    DataRow _row = dt.NewRow();
            //    _row["Name"] = "asdsad";
            //    //TestTable testtable = new TestTable();
            //    //testtable.Name = "asdasd";
            //    //_context.TestTable.AddAsync();
            //    //_context.SaveChangesAsync();
            //    //Thread.Sleep(200);
            //    dt.Rows.Add(_row);
            //}

            //return RedirectToActionResult("");
            for (int i = 0; i < 100000; i++)
            {

                _context.TestTable.Remove(_context.TestTable.Single(c => c.Id == i));
                _context.SaveChanges();
            }
            //return testtable;

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
            //    var testtable = await _context.TestTable.SingleOrDefaultAsync(c => c.Id == id);

            //    var cacheTestTable = _cache.Get<TestTable>(id);

            //return cacheTestTable;

            //}
            return await _context.TestTable.SingleOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<TestTable> GetAll()
        {
            var test = _context.TestTable.ToList();
            //IDictionary<string, TestTable> = new IDictionary<string, TestTable>();
            //NewAdd();
            //Add(NewAdd());
            //Thread a = new Thread(new ThreadStart(NewAdd));
            //a.Start();
            //a.Join();
            var count = _context.TestTable.ToList();
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
