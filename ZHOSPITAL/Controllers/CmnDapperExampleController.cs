using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZHOSPITAL.Database.Interface;
using ZHOSPITAL.Database.Utility;
using ZHOSPITAL.Models.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmnDapperExampleController : ControllerBase
    {
        private readonly IDapperExampleRepository _dapperExampleRepository;
       public CmnDapperExampleController (IDapperExampleRepository dapperExampleRepository) 
        {
            _dapperExampleRepository = dapperExampleRepository;
        }
        // GET: api/<CmnDapperExampleController>
        [HttpGet]
        public async Task<ActionResult<List<LoginResponseModel>>> Get()
        {
            var objList = await _dapperExampleRepository.GetAllData();
            //return new string[] { "value1", "value2" };
            return Ok(objList);
        }

        // GET api/<CmnDapperExampleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<LoginResponseModel>>> Get(int id)
        {
            var objList = await _dapperExampleRepository.GetData(id);
            //return new string[] { "value1", "value2" };
            return Ok(objList);
        }

        // POST api/<CmnDapperExampleController>
        [HttpPost]
        public void Post([FromBody] LoginResponseModel loginResponseModel)
        {
            _dapperExampleRepository.SaveData(loginResponseModel.name);
        }

        // PUT api/<CmnDapperExampleController>/5
        [HttpPut]
        public IActionResult Put([FromBody] LoginResponseModel loginResponseModel)
        {
            _dapperExampleRepository.UpdateData(loginResponseModel);
            return Ok();
        }

        // DELETE api/<CmnDapperExampleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
