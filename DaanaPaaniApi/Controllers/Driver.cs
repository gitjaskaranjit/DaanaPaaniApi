using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DaanaPaaniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Driver : ControllerBase
    {
        // GET: api/<Driver>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Driver>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Driver>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Driver>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Driver>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}