using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using ZAPI.Areas.VarietiesStore.ViewModel;
using ZAPI.Database.Base;
using ZAPI.Database.Interface.Authority;
using ZAPI.Models.Authority;

namespace ZAPI.Database.Repository.Authority
{
    public class RolePermissionRepository : BaseRepository<RolePermission>, IRolePermissionRepository
    {
        public List<VSRolePermissionVM> GetAll(string Module, string RoleCode, string CompanyCode)
        {
            List<VSRolePermissionVM> rolePermissionVM = new List<VSRolePermissionVM>();
            try
            {
                SqlParameter[] sqlParameters ={
                    new SqlParameter
                    {
                        ParameterName = "@Module",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = Module,
                        Size = 50
                    },
                    new SqlParameter
                    {
                        ParameterName = "@RoleCode",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = RoleCode,
                        Size = 15
                    },
                    new SqlParameter
                    {
                        ParameterName = "@CompanyCode",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = CompanyCode,
                        Size = 15
                    }
                };
                rolePermissionVM = _db.Database.SqlQueryRaw<VSRolePermissionVM>("SP_Load_RolePermissions @Module,@RoleCode,@CompanyCode", sqlParameters).ToList();
            }
            catch (Exception ex) { }
            return rolePermissionVM;
        }

        public bool PermissionSave(List<RolePermission> permissions)
        {
            bool message = false;
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("RoleCode");
                dt.Columns.Add("ControlleCode");
                dt.Columns.Add("Add");
                dt.Columns.Add("Remove");
                dt.Columns.Add("View");
                dt.Columns.Add("CompanyCode");
                for (int i = 0; i < permissions.Count; i++)
                {
                    dt.Rows.Add(permissions[i].RoleCode,
                        permissions[i].MenuCode,
                        permissions[i].Add,
                        permissions[i].Remove,
                        permissions[i].View,
                        permissions[i].CompanyCode);
                }
                SqlParameter[] sqlParameters ={
                    new SqlParameter
                    {
                        ParameterName = "@Type_RolePermissions",
                        SqlDbType = SqlDbType.Structured,
                        Value = dt,
                        TypeName = "dbo.Type_RolePermissions"
                    }
                };
                int result = 0;//_db.Database.ExecuteSqlCommand("SP_RolePermission_INSERT @Type_RolePermissions", sqlParameters);
                if (result > 0)
                {
                    message = true;
                }
            }
            catch (Exception ex) { }
            return message;
        }

        //public JsonResult RemoveMenu(string Code)
        //{
        //    RolePermissionRepository _rolePermissionRepository = new RolePermissionRepository();
        //    bool result = _rolePermissionRepository.RemoveByCode(Code);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}
