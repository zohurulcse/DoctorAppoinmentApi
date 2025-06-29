using Dapper;
using System.Data;
using ZHOSPITAL.Utility;
using ZHOSPITAL.Areas.Pharmacy.ViewModel;
using ZHOSPITAL.Database.Utility;
using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Repository.Setup
{
    public class PhDropdownProvider : IPhDropdownProvider
    {
        private readonly IDBAccess _dbAccess;
        public PhDropdownProvider(IDBAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public async Task<List<PhResponseModel>> GetAllData(int id,int shopID,string dropdownType)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<PhResponseModel>)await _con.QueryAsync<PhResponseModel>(
                sql: Convert.ToString(StoreProcedure.Name.SP_VSDropDownProvider),
                    param: new
                    {
                        ID = id,
                        Action = dropdownType,
                        ShopID = shopID
                    },
                commandType: CommandType.StoredProcedure);
            return objList ?? new List<PhResponseModel>();
        }
    }
}
