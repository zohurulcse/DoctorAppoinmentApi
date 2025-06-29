using Dapper;
using System.Data;
using System.Reflection;
using ZHOSPITAL.Database.Interface.Common;
using ZHOSPITAL.Database.Utility;
using ZHOSPITAL.Models.ViewModel;
using ZHOSPITAL.Utility;

namespace ZHOSPITAL.Database.Repository.Common
{
    public class CmnMenusPermissionRepository : ICmnMenusPermission
    {
        private readonly IDBAccess _dbAccess;
        public CmnMenusPermissionRepository(IDBAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }
        public async Task<int> SaveData(CmnMenusPermissionModel cmnMenusPermissionModel)
        {
            using var _con = _dbAccess.GetConnection();
            var result = await _con.ExecuteAsync(
                 sql: Convert.ToString(StoreProcedure.Name.SP_Load_RolePermissions),
                     param: new
                     {
                         ID = cmnMenusPermissionModel.ID,
                         ModuleID = cmnMenusPermissionModel.ModuleID,
                         RoleID = cmnMenusPermissionModel.RoleID,
                         ShopID = cmnMenusPermissionModel.ShopID,
                         UserID = cmnMenusPermissionModel.UserID,
                         IsAdd = cmnMenusPermissionModel.IsAdd,
                         IsUpdate = cmnMenusPermissionModel.IsUpdate,
                         IsView = cmnMenusPermissionModel.IsView,
                         IsDelete = cmnMenusPermissionModel.IsDelete,
                         Action = "IN"
                     },
                     commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<int> UpdateData(int id, CmnMenusPermissionModel cmnMenusPermissionModel)
        {
            using var _con = _dbAccess.GetConnection();
            var result = await _con.ExecuteAsync(
                 sql: Convert.ToString(StoreProcedure.Name.SP_Load_RolePermissions),
                     param: new
                     {
                         ID = id,
                         ModuleID = cmnMenusPermissionModel.ModuleID,
                         RoleID = cmnMenusPermissionModel.RoleID,
                         ShopID = cmnMenusPermissionModel.ShopID,
                         UserID = cmnMenusPermissionModel.UserID,
                         IsAdd = cmnMenusPermissionModel.IsAdd,
                         IsUpdate = cmnMenusPermissionModel.IsUpdate,
                         IsView = cmnMenusPermissionModel.IsView,
                         IsDelete = cmnMenusPermissionModel.IsDelete,                         
                         Action = "UP"
                     },
                     commandType: CommandType.StoredProcedure);
            return result;
        }

        //public async Task<int> SaveData(CmnMenusPermissionModel cmnMenusModel)
        //{
        //    using var _con = _dbAccess.GetConnection();
        //    var result = await _con.ExecuteAsync(
        //         sql: Convert.ToString(StoreProcedure.Name.SP_Load_RolePermissions),
        //             param: new
        //             {
        //                 //Title = cmnMenusModel.Title,
        //                 //Type = cmnMenusModel.Type,
        //                 ModuleID= cmnMenusModel.ModuleID,
        //                 //ParentID = cmnMenusModel.ParentID,
        //                 //Path= cmnMenusModel.Path,
        //                 ShopID = cmnMenusModel.ShopID,
        //                 //Icon = cmnMenusModel.Icon,
        //                 Action = "IN"
        //             },
        //             commandType: CommandType.StoredProcedure);
        //    return result;
        //}

        public async Task<int> UpdateData(CmnMenusPermissionModel cmnMenusPermissionModel)
        {
            try
            {
                using var _con = _dbAccess.GetConnection();
                var result = await _con.ExecuteAsync(
                     sql: Convert.ToString(StoreProcedure.Name.SP_Load_RolePermissions),
                         param: new
                         {
                             ID = cmnMenusPermissionModel.ID,
                             ModuleID = cmnMenusPermissionModel.ModuleID,
                             RoleID = cmnMenusPermissionModel.RoleID,
                             ShopID = cmnMenusPermissionModel.ShopID,
                             UserID = cmnMenusPermissionModel.UserID,
                             IsAdd = cmnMenusPermissionModel.IsAdd,
                             IsUpdate = cmnMenusPermissionModel.IsUpdate,
                             IsView = cmnMenusPermissionModel.IsView,
                             IsDelete = cmnMenusPermissionModel.IsDelete,
                             Action = "UP"
                         },
                         commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex) {
                return 0;
            }
           
        }

        //public async Task<int> DeleteData(int id)
        //{
        //    using var _con = _dbAccess.GetConnection();
        //    var result = await _con.ExecuteAsync(
        //         sql: Convert.ToString(StoreProcedure.Name.SP_Load_RolePermissions),
        //             param: new
        //             {
        //                 ID = id,                        
        //                 Action = "DL"
        //             },
        //             commandType: CommandType.StoredProcedure);
        //    return result;
        //}

        public async Task<List<CmnMenusPermissionModel>> GetAllData()
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<CmnMenusPermissionModel>)await _con.QueryAsync<CmnMenusPermissionModel>(
                sql: Convert.ToString(StoreProcedure.Name.SP_Load_RolePermissions),
                    param: new
                    {
                        Action = "SE"
                    },
                commandType: CommandType.StoredProcedure);


            return objList ?? new List<CmnMenusPermissionModel>();
        }

        //public async Task<CmnMenusPermissionModel> GetAllByID(int id)
        //{         

        //    using var _con = _dbAccess.GetConnection();
        //    var model = await _con.QueryFirstOrDefaultAsync<CmnMenusPermissionModel>(
        //         sql: Convert.ToString(StoreProcedure.Name.SP_Load_RolePermissions),
        //             param: new
        //             {
        //                 ID = id,
        //                 Action = "GS"
        //             },
        //             commandType: CommandType.StoredProcedure);
        //    return model ?? new CmnMenusPermissionModel();
        //}

        //public async Task<List<CmnMenusPermissionModel>> GetAllModule()
        //{
        //    using var _con = _dbAccess.GetConnection();
        //    var objList = (List<CmnMenusPermissionModel>)await _con.QueryAsync<CmnMenusPermissionModel>(
        //        sql: Convert.ToString(StoreProcedure.Name.SP_CmnModuleSetup),
        //            param: new
        //            {
        //                Action = "SE"
        //            },
        //        commandType: CommandType.StoredProcedure);


        //    return objList ?? new List<CmnMenusPermissionModel>();
        //}

        public async Task<List<CmnMenusPermissionModel>> GetMenusPermission(int moduleID, int shopID, int roleID,int shopTypeID)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<CmnMenusPermissionModel>)await _con.QueryAsync<CmnMenusPermissionModel>(
                sql: Convert.ToString(StoreProcedure.Name.SP_Load_RolePermissions),
                    param: new
                    {
                        ModuleID = moduleID,
                        RoleID = roleID,
                        ShopTypeID = shopTypeID,
                        ShopID = shopID,
                        Action = "TN"
                    },
                commandType: CommandType.StoredProcedure);


            return objList ?? new List<CmnMenusPermissionModel>();

        }

        //public async Task<List<CmnMenusPermissionModel>> GetMenuInfoList(int shopID, int roleID)
        //{
        //    using var _con = _dbAccess.GetConnection();
        //    var objList = (List<CmnMenusPermissionModel>)await _con.QueryAsync<CmnMenusPermissionModel>(
        //        sql: Convert.ToString(StoreProcedure.Name.SP_Load_Menus),
        //            param: new
        //            {
        //                RoleID = roleID,
        //                ShopID = shopID
        //            },
        //        commandType: CommandType.StoredProcedure);


        //    return objList ?? new List<CmnMenusPermissionModel>();
        //}
    }
}
