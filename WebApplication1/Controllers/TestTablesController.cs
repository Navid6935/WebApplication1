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
    public class TestTablesController : ControllerBase
    {
        private ITestTable _testTablerepository;


        public TestTablesController(ITestTable testTableRepository)
        {
            _testTablerepository = testTableRepository;

        }


        // GET: api/TestTables
        [HttpGet]
        public IActionResult GetTestTable()
        {
            var result = new ObjectResult(_testTablerepository.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            Request.HttpContext.Response.Headers.Add("X-Count", _testTablerepository.Count().ToString());

            return result;
        }

        // GET: api/TestTables/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestTable([FromRoute] int id)
        {
            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await TestTableExists(id))
            {

                var testtable = await _testTablerepository.Find(id);
                return Ok(testtable);
            }


            else
            {
                return NotFound();
            }
        }

        // PUT: api/TestTables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestTable([FromRoute] int id, [FromBody] TestTable testTable)
        {
            await _testTablerepository.Update(testTable);
            return Ok(testTable);
        }

        // POST: api/TestTables
        [HttpPost]
        public async Task<IActionResult> PostTestTable([FromBody] TestTable testTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _testTablerepository.Add(testTable);
            return CreatedAtAction("GetTestTable", new { id = testTable.Id }, testTable);

        }

        // DELETE: api/TestTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _testTablerepository.Remove(id);
            return Ok();
        }

        private async Task<bool> TestTableExists(int id)
        {
            return await _testTablerepository.IsExists(id);
        }
    }
}