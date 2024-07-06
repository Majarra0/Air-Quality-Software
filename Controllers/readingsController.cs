using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplication8.Data;
using WebApplication8.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication8.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class readingsController : ControllerBase
    {

        private MySqlDatabase db = new MySqlDatabase();

        public ActionResult Index()
        {
            DataTable dt = db.GetData("SELECT * FROM Readings");
            return Ok(dt);
        }

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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<readingsController>
        [HttpPost]
        public void Post([FromBody] Readings value)
        {
            _db.Readings.Add(value);
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
