using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Database.Interface.Common;
using ZHOSPITAL.Models.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Controllers.Authority
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmnPermissionController : ControllerBase
    {

        #region Dependency Declearation

        private readonly ICmnMenusPermission _cmnMenusPermission;

        #endregion

        #region Constructor

        public CmnPermissionController(ICmnMenusPermission cmnMenusPermission)
        {
            _cmnMenusPermission = cmnMenusPermission;
        }

        #endregion
        // GET: api/<CmnMenusController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                IList<CmnMenusPermissionModel> menuList = await _cmnMenusPermission.GetAllData();

                //Check List is Not Empty
                if (!menuList.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(menuList);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<CmnMenusController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            //try
            //{
            //    var menu = await _cmnMenusPermission.GetAllByID(id);
            //    if (menu != null)
            //    {
            //        return Ok(menu);
            //    }
            //    else
            //    {
            //        return NotFound();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            return Ok();    
        }

        // POST api/<CmnMenusController>
        [HttpPost]

        public async Task<IActionResult> Post([FromBody] CmnMenusPermissionModel cmnMenusPermissionModel)
        {
            try
            {
                int isUpdate = await _cmnMenusPermission.UpdateData(cmnMenusPermissionModel);
                if (isUpdate > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CmnMenusController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        public async Task<IActionResult> Put(int id, CmnMenusPermissionModel cmnMenusPermissionModel)
        {
            try
            {
                int isUpdate = await _cmnMenusPermission.UpdateData(cmnMenusPermissionModel);
                if (isUpdate > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CmnMenusController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //try
            //{
            //    int isDelete = await _cmnMenusPermission.DeleteData(id);
            //    if (isDelete > 0)
            //    {
            //        return Ok();
            //    }
            //    else
            //    {
            //        return BadRequest();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            return Ok();
        }

        #region Custom API Controller     

        [HttpGet("/api/CmnPermission/GetMenusPermission/{moduleID}/{shopID}/{roleID}/{shopTypeID}")]
        public async Task<ActionResult<List<CmnMenusPermissionModel>>> GetMenusPermission(int moduleID, int shopID, int roleID, int shopTypeID)
        {
            try
            {
                IList<CmnMenusPermissionModel> menuPermissionList = await _cmnMenusPermission.GetMenusPermission(moduleID, shopID, roleID,shopTypeID);
                //if (menuPermissionList.Count > 0)
                //{
                //    return Ok(menuPermissionList);
                //}
                //else
                //{
                //    return NotFound();
                //}
                //Check List is Not Empty
                if (!menuPermissionList.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NoContent();
                }
                else
                {
                    return Ok(menuPermissionList);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
