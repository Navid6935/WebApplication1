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
    public class AppUpdatesController : ControllerBase
    {
        private IAppUpdate _appUpdateRepository;


        public AppUpdatesController(IAppUpdate appUpdateRepository)
        {
            _appUpdateRepository = appUpdateRepository;

        }

        // GET: api/AppUpdates
        [HttpGet]
        public IActionResult GetAppUpdate()
        {
            var result = new ObjectResult(_appUpdateRepository.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            Request.HttpContext.Response.Headers.Add("X-Count", _appUpdateRepository.Count().ToString());

            return result;
        }
        // GET: api/AppUpdates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUpdate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await AppUpdateExists(id))
            {

                var appupdate = await _appUpdateRepository.Find(id);
                return Ok(appupdate);
            }


            else
            {
                return NotFound();
            }

        }

        // PUT: api/AppUpdates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUpdate([FromRoute] int id, [FromBody] AppUpdate appUpdate)
        {
            await _appUpdateRepository.Update(appUpdate);
            return Ok(appUpdate);
        }

        // POST: api/AppUpdates
        [HttpPost]
        public async Task<IActionResult> PostAppUpdate([FromBody] AppUpdate appUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _appUpdateRepository.Add(appUpdate);
            return CreatedAtAction("GetAppUpdate", new { id = appUpdate.AppUpdateId }, appUpdate);
        }

        // DELETE: api/AppUpdates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUpdate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _appUpdateRepository.Remove(id);
            return Ok();
        }

        private async Task<bool> AppUpdateExists(int id)
        {
            return await _appUpdateRepository.IsExists(id);
        }
    }
}