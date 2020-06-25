using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorsController : ControllerBase
    {
        private readonly Smart_Api_DBContext _context;

        public OperatorsController(Smart_Api_DBContext context)
        {
            _context = context;
        }

        // GET: api/Operators
        [HttpGet]
        public IEnumerable<Operator> GetOperator()
        {
            return _context.Operator;
        }

        // GET: api/Operators/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOperator([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @operator = await _context.Operator.FindAsync(id);

            if (@operator == null)
            {
                return NotFound();
            }

            return Ok(@operator);
        }

        // PUT: api/Operators/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperator([FromRoute] int id, [FromBody] Operator @operator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @operator.OperatorId)
            {
                return BadRequest();
            }

            _context.Entry(@operator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperatorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Operators
        [HttpPost]
        public async Task<IActionResult> PostOperator([FromBody] Operator @operator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Operator.Add(@operator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperator", new { id = @operator.OperatorId }, @operator);
        }

        // DELETE: api/Operators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperator([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @operator = await _context.Operator.FindAsync(id);
            if (@operator == null)
            {
                return NotFound();
            }

            _context.Operator.Remove(@operator);
            await _context.SaveChangesAsync();

            return Ok(@operator);
        }

        private bool OperatorExists(int id)
        {
            return _context.Operator.Any(e => e.OperatorId == id);
        }
    }
}