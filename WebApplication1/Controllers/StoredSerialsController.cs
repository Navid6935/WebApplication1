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
    public class StoredSerialsController : ControllerBase
    {
        private readonly Smart_Api_DBContext _context;

        public StoredSerialsController(Smart_Api_DBContext context)
        {
            _context = context;
        }

        // GET: api/StoredSerials
        [HttpGet]
        public IEnumerable<StoredSerials> GetStoredSerials()
        {
            return _context.StoredSerials;
        }

        // GET: api/StoredSerials/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoredSerials([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var storedSerials = await _context.StoredSerials.FindAsync(id);

            if (storedSerials == null)
            {
                return NotFound();
            }

            return Ok(storedSerials);
        }

        // PUT: api/StoredSerials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoredSerials([FromRoute] int id, [FromBody] StoredSerials storedSerials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != storedSerials.StoredSerialsId)
            {
                return BadRequest();
            }

            _context.Entry(storedSerials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoredSerialsExists(id))
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

        // POST: api/StoredSerials
        [HttpPost]
        public async Task<IActionResult> PostStoredSerials([FromBody] StoredSerials storedSerials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StoredSerials.Add(storedSerials);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoredSerials", new { id = storedSerials.StoredSerialsId }, storedSerials);
        }

        // DELETE: api/StoredSerials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoredSerials([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var storedSerials = await _context.StoredSerials.FindAsync(id);
            if (storedSerials == null)
            {
                return NotFound();
            }

            _context.StoredSerials.Remove(storedSerials);
            await _context.SaveChangesAsync();

            return Ok(storedSerials);
        }

        private bool StoredSerialsExists(int id)
        {
            return _context.StoredSerials.Any(e => e.StoredSerialsId == id);
        }
    }
}