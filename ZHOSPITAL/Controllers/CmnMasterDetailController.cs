using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Models.Setup;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmnMasterDetailController : ControllerBase
    {
        public readonly ZHOSPITALDbContext _db;
        public CmnMasterDetailController(ZHOSPITALDbContext db)
        {
            _db = db;
        }
        // GET: api/<CmnMasterDetailController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CmnMasterDetailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CmnMasterDetailController>
        [HttpPost]
        public void Post([FromBody] CmnMaster cmnMaster)
        {
            _db.CmnMaster.Add(cmnMaster);
            _db.SaveChanges();
        }

        // PUT api/<CmnMasterDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
          
        }

        // DELETE api/<CmnMasterDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
