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
    [Route("device/[controller]")]
    [Route("device/[controller]")]
    [ApiController]
    public class AppDevicesController : ControllerBase
    {
        private readonly Smart_Api_DBContext _context;

        public AppDevicesController(Smart_Api_DBContext context)
        {
            _context = context;
        }

        // GET: api/AppDevices
        [HttpGet]
        public IEnumerable<AppDevices> GetAppDevices()
        {
            return _context.AppDevices;
        }

        // GET: api/AppDevices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppDevices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appDevices = await _context.AppDevices.FindAsync(id);

            if (appDevices == null)
            {
                return NotFound();
            }

            return Ok(appDevices);
        }

        // PUT: api/AppDevices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppDevices([FromRoute] int id, [FromBody] AppDevices appDevices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appDevices.DeviceId)
            {
                return BadRequest();
            }

            _context.Entry(appDevices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppDevicesExists(id))
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

        // POST: api/AppDevices
        [HttpPost]
        public async Task<IActionResult> PostAppDevices([FromBody] AppDevices appDevices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AppDevices.Add(appDevices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppDevices", new { id = appDevices.DeviceId }, appDevices);
        }

        // DELETE: api/AppDevices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppDevices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appDevices = await _context.AppDevices.FindAsync(id);
            if (appDevices == null)
            {
                return NotFound();
            }

            _context.AppDevices.Remove(appDevices);
            await _context.SaveChangesAsync();

            return Ok(appDevices);
        }

        private bool AppDevicesExists(int id)
        {
            return _context.AppDevices.Any(e => e.DeviceId == id);
        }
    }
}