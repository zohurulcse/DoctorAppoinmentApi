using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ZHOSPITAL.Utility;

namespace ZHOSPITAL.Database.Utility
{
    public class DBAccess : IDBAccess
    {
        private readonly IConfiguration _config;
        public DBAccess(IConfiguration config) => _config = config;

        public string GetAPIToken()
        {
            return _config.GetSection("Jwt:Token").Value ?? "";
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }
        public SqlConnection GetPortalConnection()
        {
            return new SqlConnection(_config.GetConnectionString("XCAPITAL_API"));
        }
        public string GetReportApi()
        {
            return _config.GetSection("ReportApi:reportApi").Value ?? "";
        }
        public string GetSMTPSentEmail()
        {
            return _config.GetSection("Email:email").Value ?? "";
        }

        public string GetAmrstockConnection()
        {
            return "https://api.amarstock.com/";
        }

        public string GetCompanyShortCode()
        {
            return _config.GetSection("CompInfo:ShortCode").Value ?? "";
        }

        public int GetSecUserID()
        {
            return int.Parse(_config.GetSection("CompInfo:UserID").Value ?? "0");
        }

        public string GetCTitle()
        {
            return _config.GetSection("CompInfo:CTitle").Value ?? "";
        }

        //public async Task<int> GetStockID()
        //{
        //    using var _con = GetPortalConnection();
        //    var objlist = await _con.QueryFirstOrDefaultAsync<CompanySettings>(
        //        sql: Convert.ToString(StoreProcedure.Name.Company_SP_Setup),
        //            param: new
        //            {
        //                Action = "CQ",
        //            },
        //        commandType: CommandType.StoredProcedure);
        //    return objlist.IsStockEnable ? 1 : 0;
        //}

        public string CreateToken(string email, string cellNo)
        {
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Name, cellNo),
                new Claim("JoinDate", DateTime.Now.ToString()),
                new Claim("UserID", email),
                new Claim("Email", email),
                new Claim("CellNo", cellNo),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(GetAPIToken()));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
