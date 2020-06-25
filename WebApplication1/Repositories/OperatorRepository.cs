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
    public class OperatorRepository : IOperator
    {
        private Smart_Api_DBContext _context;
        private IMemoryCache _cache;

        public OperatorRepository(Smart_Api_DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<Operator> Add(Operator operaator)
        {
            await _context.Operator.AddAsync(operaator);
            await _context.SaveChangesAsync();

            return operaator;
        }

        public async Task<int> Count()
        {
            return await _context.Operator.CountAsync();
        }

        public async Task<Operator> Find(int id)
        {
            return await _context.Operator.SingleOrDefaultAsync(c => c.OperatorId == id);
        }

        public IEnumerable<Operator> GetAll()
        {
            return _context.Operator.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Operator.AnyAsync(c => c.OperatorId == id);
        }

        public async Task<Operator> Remove(int id)
        {
            var Operator = await _context.Operator.SingleAsync(c => c.OperatorId == id);
            _context.Operator.Remove(Operator);
            await _context.SaveChangesAsync();
            return Operator;
        }

        public async Task<Operator> Update(Operator operaator)
        {
            _context.Update(operaator);
            await _context.SaveChangesAsync();
            return operaator;
        }
    }
}
