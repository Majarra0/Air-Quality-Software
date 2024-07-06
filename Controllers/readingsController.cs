using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Data;
using WebApplication8.Data;
using WebApplication8.Models;
using WebApplication8.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication8.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class readingsController : ControllerBase
    {

        private MySqlDatabase db = new MySqlDatabase();

        private readonly dbContext _db;

        public readingsController(dbContext dbContext)
        {
            _db = dbContext;
        }

        // GET: api/<readingsController>
        [HttpGet]
        public Readings Get()
        {
            return _db.Readings.OrderByDescending(r => r.CreatedAt).FirstOrDefault();
        }

        // GET api/<readingsController>/5
        [HttpGet("{id}")]
        public Readings Get(int read)
        {
            return _db.Readings.FirstOrDefault(x => x.AirQ == read);
        }

        // POST api/<readingsController>
        [HttpPost]
        public void Post([FromBody] Readings value)
        {
            _db.Readings.Add(value);
            _db.SaveChanges();
        }

        // POST api/<readingsController>
        [HttpPost("messagepost")]
        public void PostM(string sms)
        {
            var obj = new Messages { Id = 0, message = sms };
            _db.Messages.Add(obj);
            _db.SaveChanges();
        }

        // PUT api/<readingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<readingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
