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
    public class EspSerialActives1Controller : ControllerBase
    {
        private readonly Smart_Api_DBContext _context;

        public EspSerialActives1Controller(Smart_Api_DBContext context)
        {
            _context = context;
        }

        // GET: api/EspSerialActives1
        [HttpGet]
        public IEnumerable<EspSerialActive> GetEspSerialActive()
        {
            return _context.EspSerialActive;
        }

        // GET: api/EspSerialActives1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEspSerialActive([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var espSerialActive = await _context.EspSerialActive.FindAsync(id);

            if (espSerialActive == null)
            {
                return NotFound();
            }

            return Ok(espSerialActive);
        }

        // PUT: api/EspSerialActives1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspSerialActive([FromRoute] int id, [FromBody] EspSerialActive espSerialActive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != espSerialActive.EsId)
            {
                return BadRequest();
            }

            _context.Entry(espSerialActive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspSerialActiveExists(id))
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

        // POST: api/EspSerialActives1
        [HttpPost]
        public async Task<IActionResult> PostEspSerialActive([FromBody] EspSerialActive espSerialActive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EspSerialActive.Add(espSerialActive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspSerialActive", new { id = espSerialActive.EsId }, espSerialActive);
        }

        // DELETE: api/EspSerialActives1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspSerialActive([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var espSerialActive = await _context.EspSerialActive.FindAsync(id);
            if (espSerialActive == null)
            {
                return NotFound();
            }

            _context.EspSerialActive.Remove(espSerialActive);
            await _context.SaveChangesAsync();

            return Ok(espSerialActive);
        }

        private bool EspSerialActiveExists(int id)
        {
            return _context.EspSerialActive.Any(e => e.EsId == id);
        }
    }
}