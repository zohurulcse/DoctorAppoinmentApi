using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using ZHOSPITAL.Utility;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Database.Interface;
using ZHOSPITAL.Database.Utility;
using ZHOSPITAL.Models.Setup;
using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Database.Repository
{
    public class DapperExampleRepository : IDapperExampleRepository

    {
        private readonly IDBAccess _dbAccess;
        public DapperExampleRepository(IDBAccess dBAccess)
        {
            _dbAccess = dBAccess;
        }

        public async Task<int> SaveData(string name)
        {
            using var _con = _dbAccess.GetConnection();
            var result = await _con.ExecuteAsync(
                 sql: Convert.ToString(StoreProcedure.Name.SPDapperTest),
                     param: new
                     {
                         Name = name,
                         Action = "IN"
                     },
                     commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<List<LoginResponseModel>> GetAllData()
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<LoginResponseModel>)await _con.QueryAsync<LoginResponseModel>(
                sql: Convert.ToString(StoreProcedure.Name.SPDapperTest),
                    param: new
                    {
                        Action = "SE"
                    },
                commandType: CommandType.StoredProcedure);
            return objList ?? new List<LoginResponseModel>();
        }

        public async Task<LoginResponseModel> GetData(int id)
        {
            using var _con = _dbAccess.GetConnection();
            var model = await _con.QueryFirstOrDefaultAsync<LoginResponseModel>(
                 sql: Convert.ToString(StoreProcedure.Name.SPDapperTest),
                     param: new
                     {
                         ID = id,
                         Action = "GS"
                     },
                     commandType: CommandType.StoredProcedure);           
            return model;
        }

        public async Task<int> UpdateData(LoginResponseModel loginResponseModel)
        {
            using var _con = _dbAccess.GetConnection();
            var result = await _con.ExecuteAsync(
                 sql: Convert.ToString(StoreProcedure.Name.SPDapperTest),
                     param: new
                     {
                         ID = loginResponseModel.id,
                         Name = loginResponseModel.name,
                         Action = "UP"
                     },
                     commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}


