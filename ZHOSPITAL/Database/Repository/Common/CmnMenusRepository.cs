using Dapper;
using System.Data;
using System.Reflection;
using ZHOSPITAL.Database.Interface.Common;
using ZHOSPITAL.Database.Utility;
using ZHOSPITAL.Models.ViewModel;
using ZHOSPITAL.Utility;

namespace ZHOSPITAL.Database.Repository.Common
{
    public class CmnMenusRepository : ICmnMenus
    {
        private readonly IDBAccess _dbAccess;
        public CmnMenusRepository(IDBAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public async Task<int> SaveData(CmnMenusModel cmnMenusModel)
        {
            try
            {
                using var _con = _dbAccess.GetConnection();
                var result = await _con.ExecuteAsync(
                     sql: Convert.ToString(StoreProcedure.Name.SP_CmnMenuSetup),
                         param: new
                         {
                             ID             = 0,
                             SLNo           = cmnMenusModel.SLNo,
                             Type           =   cmnMenusModel.Type,
                             NavigationType =   cmnMenusModel.NavigationType,
                             Title          =   cmnMenusModel.Title,
                             ModuleID       =   cmnMenusModel.ModuleID,
                             ParentID       =   cmnMenusModel.ParentID,
                             Path           =   cmnMenusModel.Path,
                             ShopTypeID     =   cmnMenusModel.ShopTypeID,
                             ShopID         =   cmnMenusModel.ShopID,
                             Icon           =   cmnMenusModel.Icon,
                             Action         =   "IN"
                         },
                         commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> UpdateData(int id, CmnMenusModel cmnMenusModel)
        {
            using var _con = _dbAccess.GetConnection();
            var result = await _con.ExecuteAsync(
                 sql: Convert.ToString(StoreProcedure.Name.SP_CmnMenuSetup),
                     param: new
                     {
                         ID = id,
                         Title = cmnMenusModel.Title,
                         Type = cmnMenusModel.Type,
                         NavigationType = cmnMenusModel.NavigationType,
                         ModuleID = cmnMenusModel.ModuleID,
                         ParentID = cmnMenusModel.ParentID,
                         Path = cmnMenusModel.Path,
                         ShopTypeID = cmnMenusModel.ShopTypeID,
                         ShopID = cmnMenusModel.ShopID,
                         Icon = cmnMenusModel.Icon,
                         SLNo = cmnMenusModel.SLNo,
                         Action = "UP"
                     },
                     commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<int> DeleteData(int id)
        {
            using var _con = _dbAccess.GetConnection();
            var result = await _con.ExecuteAsync(
                 sql: Convert.ToString(StoreProcedure.Name.SP_CmnMenuSetup),
                     param: new
                     {
                         ID = id,
                         Action = "DL"
                     },
                     commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<List<CmnMenusModel>> GetAllData()
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<CmnMenusModel>)await _con.QueryAsync<CmnMenusModel>(
                sql: Convert.ToString(StoreProcedure.Name.SP_CmnMenuSetup),
                    param: new
                    {
                        Action = "SE"
                    },
                commandType: CommandType.StoredProcedure);


            return objList ?? new List<CmnMenusModel>();
        }

        public async Task<List<CmnMenusModel>> GetAllByID(int id)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<CmnMenusModel>)await _con.QueryAsync<CmnMenusModel>(
                sql: Convert.ToString(StoreProcedure.Name.SP_CmnMenuSetup),
                    param: new
                    {
                        ID = id,
                        Action = "GS"
                    },
                commandType: CommandType.StoredProcedure);


            return objList ?? new List<CmnMenusModel>();
        }

        public async Task<List<CmnMenusModuleModel>> GetAllModule()
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<CmnMenusModuleModel>)await _con.QueryAsync<CmnMenusModuleModel>(
                sql: Convert.ToString(StoreProcedure.Name.SP_CmnModuleSetup),
                    param: new
                    {
                        Action = "SE"
                    },
                commandType: CommandType.StoredProcedure);


            return objList ?? new List<CmnMenusModuleModel>();
        }

        public async Task<List<CmnMenusModel>> GetMenuSlNo(int shopTypeID)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<CmnMenusModel>)await _con.QueryAsync<CmnMenusModel>(
                sql: Convert.ToString(StoreProcedure.Name.SP_CmnMenuSetup),
                    param: new
                    {
                        ShopTypeID = shopTypeID,
                        Action = "SL"
                    },
                commandType: CommandType.StoredProcedure);


            return objList;
        }

        public async Task<List<MenuInfoModelResponse>> GetMenuInfoModel(int shopID, int roleID)
        {
            var resList = new List<MenuInfoModelResponse>();
            var resList2 = new List<MenuInfoModelResponse>();
            var objlist = await GetMenuInfoList(shopID, roleID);
            var _parentId = 0;
            foreach (var item in objlist)
            {
                var itemList = new List<MenuInfoModel>();
                var itemList2 = new List<MenuInfoModelResponse>();
                var resObj = new MenuInfoModelResponse();
                var newList = objlist.Where(m => m.ParentID == item.ParentID).ToList();
                if (newList.Count >= 1 && _parentId != item.ParentID)
                {
                    _parentId = item.ParentID;
                    foreach (var item2 in newList)
                    {                       
                        //if (item2.Type != "sub")
                        //{
                        //    itemList.Add(item2);
                        ////}
                        //if (item2.NavigationType == "Child")
                        //{
                        //    itemList.Add(item2);
                        //}
                        if (item2.NavigationType == "Parent")// && _parentId != item2.ParentID
                        {
                            var childListOnParents = objlist.Where(m => m.ParentID == item2.MenuID && m.NavigationType == "Child" && m.Type == "link").ToList();

                            if (childListOnParents.Count > 0)
                            {
                                itemList2 = new List<MenuInfoModelResponse>();

                                foreach (var m2 in childListOnParents)
                                {

                                    if (m2.Type != "sub")
                                    {
                                        //itemList2.Add(m2);
                                        resList2.Add(m2);
                                    }
                                       
                                }
                          
                            }
                            else
                            {
                                //if (item2.MenuID >= 1)
                                //{
                                //    resObj = new MenuInfoModelResponse
                                //    {
                                //        MenuID = item2.MenuID,
                                //        headTitle = item2.headTitle,
                                //        Title = item2.Title,
                                //        Path = item2.Path,
                                //        Icon = item2.Icon,
                                //        Type = item2.Type,
                                //        ParentID = item2.ParentID,
                                //        LayerID = item2.LayerID,
                                //        IsActive = item2.IsActive,
                                //        children = null
                                //    };
                                //}
                                resList2 = new List<MenuInfoModelResponse>();
                                //resList2.Add(resObj);
                                //resObj.MenuID = 0;
                            }

                        }
                        else if (item2.NavigationType == "Child Parent")
                        {
                            var childListOnChildParents = objlist.Where(m => m.ParentID == item2.MenuID && m.NavigationType == "Child").ToList();                           

                            if (childListOnChildParents != null)
                            {
                                itemList2 = new List<MenuInfoModelResponse>();

                                foreach (var m2 in childListOnChildParents)
                                {
                                    itemList2.Add(m2);
                                }



                                if (item2.MenuID >= 1)
                                {
                                    resObj = new MenuInfoModelResponse
                                    {
                                        MenuID = item2.MenuID,
                                        headTitle = item2.headTitle,
                                        Title = item2.Title,
                                        Path = item2.Path,
                                        Icon = item2.Icon,
                                        Type = item2.Type,
                                        ParentID = item2.ParentID,
                                        LayerID = item2.LayerID,
                                        IsActive = item2.IsActive,
                                        children = itemList2
                                    };
                                }
                            }
                            else
                            {
                                if (item2.MenuID >= 1)
                                {
                                    resObj = new MenuInfoModelResponse
                                    {
                                        MenuID = item2.MenuID,
                                        headTitle = item2.headTitle,
                                        Title = item2.Title,
                                        Path = item2.Path,
                                        Icon = item2.Icon,
                                        Type = item2.Type,
                                        ParentID = item2.ParentID,
                                        LayerID = item2.LayerID,
                                        IsActive = item2.IsActive,
                                        children = null
                                    };
                                }
                            }


                            resList2.Add(resObj);
                            resObj.MenuID = 0;
                        }

                    }
                  
                    var m = newList.Where(m => m.MenuID == item.ParentID).FirstOrDefault();
                    if (m != null)
                    {
                        if (m.MenuID >= 1)
                        {
                            resObj = new MenuInfoModelResponse
                            {
                                MenuID = m.MenuID,
                                headTitle = m.headTitle,
                                Title = m.Title,
                                Path = m.Path,
                                Icon = m.Icon,
                                Type = m.Type,
                                ParentID = m.ParentID,
                                LayerID = m.LayerID,
                                IsActive = m.IsActive,
                                children = resList2
                            };
                        }
                    }
                   
                 
                }
                else if (newList.Count == 1)
                {
                    resObj = new MenuInfoModelResponse
                    {
                        MenuID = item.MenuID,
                        headTitle = item.headTitle,
                        Title = item.Title,
                        Path = item.Path,
                        Icon = item.Icon,
                        Type = item.Type,
                        ParentID = item.ParentID,
                        LayerID = item.LayerID,
                        IsActive = item.IsActive,



                    };
                }

                if (resObj.MenuID > 0)
                {
                    var dd = resList.Where(x => x.ParentID == resObj.ParentID).FirstOrDefault();
                    if (dd == null) {
                        resList.Add(resObj);
                        resObj.MenuID = 0;
                        resList2 = new List<MenuInfoModelResponse>();
                    }
                                     
                }
            }
            return resList;


        }

        public async Task<List<MenuInfoModelResponse>> GetMenuInfoList(int shopID, int roleID)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<MenuInfoModelResponse>)await _con.QueryAsync<MenuInfoModelResponse>(
                sql: Convert.ToString(StoreProcedure.Name.SP_Load_Menus),
                    param: new
                    {
                        RoleID = roleID,
                        ShopID = shopID
                    },
                commandType: CommandType.StoredProcedure);


            return objList ?? new List<MenuInfoModelResponse>();
        }
    }
}
