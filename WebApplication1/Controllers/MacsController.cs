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
    public class MacsController : ControllerBase
    {
        private readonly Smart_Api_DBContext _context;

        public MacsController(Smart_Api_DBContext context)
        {
            _context = context;
        }

        // GET: api/Macs
        [HttpGet]
        public IEnumerable<Mac> GetMac()
        {
            return _context.Mac;
        }

        // GET: api/Macs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMac([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mac = await _context.Mac.FindAsync(id);

            if (mac == null)
            {
                return NotFound();
            }

            return Ok(mac);
        }

        // PUT: api/Macs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMac([FromRoute] int id, [FromBody] Mac mac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mac.MacId)
            {
                return BadRequest();
            }

            _context.Entry(mac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MacExists(id))
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

        // POST: api/Macs
        [HttpPost]
        public async Task<IActionResult> PostMac([FromBody] Mac mac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Mac.Add(mac);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMac", new { id = mac.MacId }, mac);
        }

        // DELETE: api/Macs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMac([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mac = await _context.Mac.FindAsync(id);
            if (mac == null)
            {
                return NotFound();
            }

            _context.Mac.Remove(mac);
            await _context.SaveChangesAsync();

            return Ok(mac);
        }

        private bool MacExists(int id)
        {
            return _context.Mac.Any(e => e.MacId == id);
        }
    }
}