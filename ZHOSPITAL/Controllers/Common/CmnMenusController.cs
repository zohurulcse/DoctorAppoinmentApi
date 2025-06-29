using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZHOSPITAL.Database.Interface;
using ZHOSPITAL.Database.Interface.Common;
using ZHOSPITAL.Models.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmnMenusController : ControllerBase
    {
        #region Dependency Declearation

        private readonly ICmnMenus _cmnMenus;

        #endregion

        #region Constructor

        public CmnMenusController(ICmnMenus cmnMenus)
        {
            _cmnMenus = cmnMenus;            
        }

        #endregion
        // GET: api/<CmnMenusController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                IList<CmnMenusModel> menuList = await _cmnMenus.GetAllData();

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

            try
            {
                List<CmnMenusModel> menu = await _cmnMenus.GetAllByID(id);
                if (menu != null)
                {
                    return Ok(menu);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CmnMenusController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CmnMenusModel cmnMenusModel)
        {            
            try
            {
                int isSaved = await _cmnMenus.SaveData(cmnMenusModel);
                if (isSaved > 0)
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
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CmnMenusModel cmnMenusModel)
        {
            try
            {
                int isUpdate = await _cmnMenus.UpdateData(id,cmnMenusModel);
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
            try
            {
                int isDelete = await _cmnMenus.DeleteData(id);
                if (isDelete > 0)
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

        #region Custom API Controller


        //[HttpGet("/api/CmnMenus/GetMenus/{shopID}/{roleID}")]
        //public async Task<IActionResult> GetMenus(int shopID, int roleID)
        //{
        //    try
        //    {
        //        var menus2 = new List<CmnMenusModel>();
        //        var child = new List<CmnMenusModel>();


        //        IList<CmnMenusModel> menus = await _cmnMenus.GetAllData(shopID, roleID);

        //        CmnMenusModel dd = new CmnMenusModel();

        //        foreach (var data in menus)
        //        {
        //            //menus2.Add(data);
        //            //dd.HeadTitle = data.Title;
        //            //data.children.Add(dd);


        //            if (data.Type == "sub")
        //            {
        //                menus2.Add(new CmnMenusModel
        //                {
        //                    Title = data.Title,
        //                    Type = data.Type,
        //                    HeadTitle = data.HeadTitle,
        //                    Path = data.Path,
        //                    children = new List<CmnMenusModel>
        //               {
        //                    //new CmnMenusModel
        //                    //{
        //                    //    Title = data.Title,
        //                    //    Type = data.Type,
        //                    //    HeadTitle = data.HeadTitle,
        //                    //    Path = data.Path,
        //                    //},

        //               }
        //                });
        //            }
        //            else
        //            {
        //                menus2.Add(new CmnMenusModel
        //                {
        //                    //Title = data.Title,
        //                    //Type = data.Type,
        //                    //HeadTitle = data.HeadTitle,
        //                    //Path = data.Path,
        //                    children = new List<CmnMenusModel>
        //               {
        //                    new CmnMenusModel
        //                    {
        //                        Title = data.Title,
        //                        Type = data.Type,
        //                        HeadTitle = data.HeadTitle,
        //                        Path = data.Path,
        //                    },

        //               }
        //                });
        //            }

                    //if (data.Type == "link")
                    //{
                    //    if(data.ID == data.ParentID)
                    //    {
                    //        child.Add(data);
                    //    }
                        
                    //}

                    //if (data.Type == "sub")
                    //{
                    //    menus2.Add(new CmnMenusModel
                    //    {
                    //        Title = data.Title,
                    //        Type = data.Type,
                    //        HeadTitle = data.HeadTitle,
                    //        Path = data.Path,
                    //        children = child,
                    //        //children = new List<CmnMenusModel>
                    //        //{
                    //        //    new CmnMenusModel
                    //        //    {
                    //        //        Title = data.Title,
                    //        //        Type = data.Type,
                    //        //        HeadTitle = data.HeadTitle,
                    //        //        Path = data.Path,
                    //        //    },

                    //        //}
                    //    });
                    //}
                    //else
                    //{

                    // menus2.Add(new CmnMenusModel
                    // {
                    //     //Title = data.Title,
                    //     //Type = data.Type,
                    //     //HeadTitle = data.HeadTitle,
                    //     //Path = data.Path,
                    //     children = new List<CmnMenusModel>
                    //{
                    //     new CmnMenusModel
                    //     {
                    //         Title = data.Title,
                    //         Type = data.Type,
                    //         HeadTitle = data.HeadTitle,
                    //         Path = data.Path,
                    //     },

                    //}
                    // });
                    //}




        //        }


        //        //Check List is Not Empty
        //        if (!menus.ToList().Any())
        //        {
        //            //If List is Empty Then Send NotFound Status
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return Ok(menus);
        //        }

                //Check List is Not Empty
                //if (!menus2.ToList().Any())
                //{
                //    //If List is Empty Then Send NotFound Status
                //    return NotFound();
                //}
                //else
                //{
                //    return Ok(menus2);
                //}


        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpGet("/api/CmnMenus/GetMenus/{shopID}/{roleID}")]
        public async Task<ActionResult<List<MenuInfoModelResponse>>> MenuInfoList(int shopID, int roleID)
        {
            try
            {
                var obj = await _cmnMenus.GetMenuInfoModel(shopID, roleID);
                if (obj != null && obj.Count > 0)
                {
                    return Ok(obj);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/CmnMenus/GetMenuSlNo/{shopTypeID}")]
        public async Task<ActionResult<List<CmnMenusModel>>> GetMenuSlNo(int shopTypeID)
        {
            try
            {
                var obj = await _cmnMenus.GetMenuSlNo(shopTypeID);
                if (obj != null)
                {
                    return Ok(obj);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/CmnMenus/GetModule")]
        public async Task<ActionResult<List<CmnMenusModuleModel>>> ModuleInfoList()
        {
            try
            {
               List<CmnMenusModuleModel> moduleList = await _cmnMenus.GetAllModule();
                if (moduleList.Count > 0)
                {
                    return Ok(moduleList);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
