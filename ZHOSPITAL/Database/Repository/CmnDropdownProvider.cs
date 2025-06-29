using Dapper;
using System.Data;
using ZHOSPITAL.Utility;
using ZHOSPITAL.Database.Utility;
using ZHOSPITAL.Models.ViewModel;
using ZHOSPITAL.Database.Interface.Common;

namespace ZHOSPITAL.Database.Data.Repository.Setup
{
    public class CmnDropdownProvider : ICmnDropdownProvider
    {
        private readonly IDBAccess _dbAccess;
        public CmnDropdownProvider(IDBAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public async Task<List<DropdownResponseModel>> GetAllData(int id,int shopID,string dropdownType)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<DropdownResponseModel>)await _con.QueryAsync<DropdownResponseModel>(
                sql: Convert.ToString(StoreProcedure.Name.SP_ZBDropDownProvider),
                    param: new
                    {
                        ID = id,
                        Action = dropdownType,
                        ShopID = shopID
                    },
                commandType: CommandType.StoredProcedure);
            return objList ?? new List<DropdownResponseModel>();
        }
    }
}
