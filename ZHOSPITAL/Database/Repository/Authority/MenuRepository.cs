using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ZAPI.Database.Base;
using ZAPI.Database.Interface.Authority;
using ZAPI.Models.Authority;

namespace ZAPI.Database.Repository.Authority
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public List<Menu> GetAll(string CompanyCode)
        {
            List<Menu> menus = _db.Menus.Where(c => c.CompanyCode == CompanyCode && c.SLNO != null || c.SLNO != 0).OrderByDescending(c => c.SLNO).ToList();
            return menus;
        }
        public List<Menu> GetAll(string CompanyCode, string SearchValue)
        {
            SearchValue = SearchValue.ToLower();
            List<Menu> menus = _db.Menus.Where(c => c.CompanyCode == CompanyCode && (c.Code.ToLower().Contains(SearchValue)
                                                                                     || c.Name.ToLower().Contains(SearchValue)
                                                                                     || c.Module.ToLower().Contains(SearchValue)
                                                                                     || c.Url.ToLower().Contains(SearchValue))).OrderBy(c => c.SLNO).ToList();
            return menus;
        }
        public List<Menu> GetAll(string CompanyCode, string Module, string RoleCode)
        {
            List<Menu> menus = new List<Menu>();
            try
            {
                SqlParameter[] sqlParameters ={
                    new SqlParameter
                    {
                        ParameterName = "@CompanyCode",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = CompanyCode,
                        Size=15
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Module",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = Module,
                        Size=50
                    },
                    new SqlParameter
                    {
                        ParameterName = "@RoleCode",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = RoleCode,
                        Size=15
                    }
                };

                menus = _db.Database.SqlQueryRaw<Menu>("SP_Load_Menus @Module,@RoleCode", sqlParameters).ToList();
            }
            catch (Exception ex) { }
            return menus;
        }

        public bool RemoveMenu(string Code)
        {
            bool isSaved = false;
            try
            {
                SqlParameter[] sqlParameters ={
                    new SqlParameter
                    {
                        ParameterName = "@Code",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = Code,
                        Size=15
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Action",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = "DE",
                        Size=2
                    }

                };
                int result = 0;//_db.Database.ExecuteSqlCommand("SP_MENU @Code,@Action", sqlParameters);
                if (result > 0)
                {
                    isSaved = true;
                }
            }
            catch (Exception ex) { }
            return isSaved;
        }
    }
}
