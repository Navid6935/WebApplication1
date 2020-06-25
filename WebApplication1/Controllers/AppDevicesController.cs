using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppDevicesController : ControllerBase
    {
        private IAppDevices _appDeviceRepository;


        public AppDevicesController(IAppDevices appDeviceRepositiory)
        {
            _appDeviceRepository = appDeviceRepositiory;

        }


        // GET: api/AppDevices
        [HttpGet]
        public IActionResult GetAppDevices()
        {
            var result = new ObjectResult(_appDeviceRepository.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            Request.HttpContext.Response.Headers.Add("X-Count", _appDeviceRepository.Count().ToString());

            return result;
        }

        // GET: api/AppDevices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppDevices([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await AppDevicesExists(id))
            {

                var appdevice = await _appDeviceRepository.Find(id);
                return Ok(appdevice);
            }


            else
            {
                return NotFound();
            }
        }

        // PUT: api/AppDevices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppDevices([FromRoute] int id, [FromBody] AppDevices appDevices)
        {
            await _appDeviceRepository.Update(appDevices);
            return Ok(appDevices);
        }

        // POST: api/AppDevices
        [HttpPost]
        public async Task<IActionResult> PostAppDevices([FromBody] AppDevices appDevices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _appDeviceRepository.Add(appDevices);
            return CreatedAtAction("GetAppDevices", new { id = appDevices.Id }, appDevices);
        }

        // DELETE: api/AppDevices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppDevices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _appDeviceRepository.Remove(id);
            return Ok();
        }

        private async Task<bool> AppDevicesExists(int id)
        {
            return await _appDeviceRepository.IsExists(id);
        }
    }
}