using Dapper;
using System.Data;
using ZHOSPITAL.Utility;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Database.Utility;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Repository.Common
{
    public class PhCustomCodeGenerateRepository : IPhCustomCodeGenerate
    {
        private readonly IDBAccess _db;
        public PhCustomCodeGenerateRepository(IDBAccess db) 
        {
            _db = db;
        }
        public async Task<string> CodeGenerator(string prefix, string table, string columnname, int shopID )
        {
            string Code = string.Empty;

            using var _con = _db.GetConnection();
            var objList = await _con.QueryFirstOrDefaultAsync<string>(
                sql: Convert.ToString(StoreProcedure.Name.SP_CREATE_CODE),
                    param: new
                    {
                        PREFIX = prefix,
                        TABLE = table,
                        COLUMNNAME = columnname,
                        SHOPID = shopID
                    },
                commandType: CommandType.StoredProcedure);
            return objList ?? "0";

        }

        public dynamic PurchaseCodeGenerator(int shopID)
        {

            try
            {
                using var _con = _db.GetConnection();
                var result = _con.Query<string>("SELECT dbo.FSN_PURCHASE_Head_CODE(@ShopID)",
                    new
                    {                        
                        ShopID = shopID
                    },
                    commandType: CommandType.Text);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public dynamic SaleCodeGenerator(int shopID)
        {

            try
            {
                using var _con = _db.GetConnection();
                var result = _con.Query<string>("SELECT dbo.FSN_SALE_HEAD_CUSTOMCODE(@ShopID)",
                    new
                    {
                        ShopID = shopID
                    },
                    commandType: CommandType.Text);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
