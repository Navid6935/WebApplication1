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
    public class AppUsersController : ControllerBase
    {
        private IAppUsers _appusersripository;


        public AppUsersController(IAppUsers appusersRepository)
        {
            _appusersripository = appusersRepository;

        }


        // GET: api/AppUsers
        [HttpGet]
        public IActionResult GetAppUsers()
        {
            var result = new ObjectResult(_appusersripository.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            Request.HttpContext.Response.Headers.Add("X-Count", _appusersripository.Count().ToString());

            return result;
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await AppUsersExists(id))
            {

                var appupdate = await _appusersripository.Find(id);
                return Ok(appupdate);
            }


            else
            {
                return NotFound();
            }
        }

        // PUT: api/AppUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUsers([FromRoute] int id, [FromBody] AppUsers appUsers)
        {
            await _appusersripository.Update(appUsers);
            return Ok(appUsers  );
        }


        // POST: api/AppUsers
        [HttpPost]
        public async Task<IActionResult> PostAppUsers([FromBody] AppUsers appUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _appusersripository.Add(appUsers);
            return CreatedAtAction("GetAppUsers", new { id = appUsers.UserId }, appUsers);
        }

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _appusersripository.Remove(id);
            return Ok();
        }

        private async Task<bool> AppUsersExists(int id)
        {
            return await _appusersripository.IsExists(id);
        }
    }
}