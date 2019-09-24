using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp2.API.Data;
using DatingApp2.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }
        
        // GET api/values
        [HttpGet]
        public IActionResult GetValues()
        {
            List<Value> values = _context.Values.ToList();

            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            Value value = _context.Values.FirstOrDefault(v => v.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
