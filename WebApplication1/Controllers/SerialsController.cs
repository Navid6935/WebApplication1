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
    public class SerialsController : ControllerBase
    {
        private readonly Smart_Api_DBContext _context;

        public SerialsController(Smart_Api_DBContext context)
        {
            _context = context;
        }

        // GET: api/Serials
        [HttpGet]
        public IEnumerable<Serial> GetSerial()
        {
            return _context.Serial;
        }

        // GET: api/Serials/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serial = await _context.Serial.FindAsync(id);

            if (serial == null)
            {
                return NotFound();
            }

            return Ok(serial);
        }

        // PUT: api/Serials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerial([FromRoute] int id, [FromBody] Serial serial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serial.SerialId)
            {
                return BadRequest();
            }

            _context.Entry(serial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerialExists(id))
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

        // POST: api/Serials
        [HttpPost]
        public async Task<IActionResult> PostSerial([FromBody] Serial serial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Serial.Add(serial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerial", new { id = serial.SerialId }, serial);
        }

        // DELETE: api/Serials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serial = await _context.Serial.FindAsync(id);
            if (serial == null)
            {
                return NotFound();
            }

            _context.Serial.Remove(serial);
            await _context.SaveChangesAsync();

            return Ok(serial);
        }

        private bool SerialExists(int id)
        {
            return _context.Serial.Any(e => e.SerialId == id);
        }
    }
}