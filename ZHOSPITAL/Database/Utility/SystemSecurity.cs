using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using ZHOSPITAL.Database.Interface.Authority;
using Microsoft.Data.SqlClient;
using ZHOSPITAL.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ZHOSPITAL.Database.Utility;
using Dapper;
using ZHOSPITAL.Utility;
using ZHOSPITAL.Models.Authority;

namespace ZHOSPITAL.Database
{
    public class SystemSecurity : BaseRepository<CmnUser>, ISystemSecurity
    {
        private readonly IConfiguration _config;
        private readonly IDBAccess _dbAccess;
        public SystemSecurity(ZHOSPITALDbContext db, IConfiguration config, IDBAccess dbAccess) : base(db)
        {
            _config = config;
            _dbAccess = dbAccess;
        }

        //public SMARTBAZARContext _db = new SMARTBAZARContext();
        //public string Permission(string Url, string Action)
        //{
        //    string result = "Somethingiswrong";
        //    try
        //    {
        //        Url = Url.Replace("/Edit", "/Add");
        //        //if (HttpContext.Current.Session["RoleCode"] == null)
        //        //{
        //        //    return result = "SessionOut";
        //        //}
        //        string RoleCode = "";//HttpContext.Current.Session["RoleCode"].ToString();
        //        SqlParameter[] sqlParameters ={
        //            new SqlParameter
        //            {
        //                ParameterName = "@RoleCode",
        //                SqlDbType = SqlDbType.NVarChar,
        //                Value = RoleCode,
        //                Size=15
        //            },
        //            new SqlParameter
        //            {
        //                ParameterName = "@Url",
        //                SqlDbType = SqlDbType.NVarChar,
        //                Value = Url,
        //                Size=150
        //            },
        //            new SqlParameter
        //            {
        //                ParameterName = "@Action",
        //                SqlDbType = SqlDbType.NVarChar,
        //                Value = Action,
        //                Size=6
        //            }
        //        };

        //        bool status = _db.Database.SqlQueryRaw<bool>("SP_CheckRolePermission @RoleCode,@Url,@Action", sqlParameters).FirstOrDefault();
        //        if (status)
        //        {
        //            result = "True";
        //        }
        //        else
        //        {
        //            result = "InsufficientPermissions";
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return result;
        //}

    
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public string CreateToken(string userID, string email, string mobile)
        {
            var ss = GetAPIToken();
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Name, mobile),
                new Claim("Date", DateTime.Now.ToString()),
                new Claim("UserID", userID),
                new Claim("Email", email),
                new Claim("Mobile", mobile),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(GetAPIToken()));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public string GetAPIToken()
        {
            return _config.GetSection("Jwt:Token").Value ?? "";
        }

        public async Task<int> Permission(int shopID, int roleID, int userID, string Url, string Action, string apiMethod)
        {
            using var _con = _dbAccess.GetConnection();
            var model = await _con.QueryFirstOrDefaultAsync<int>(
                 sql: Convert.ToString(StoreProcedure.Name.SP_CheckRolePermission),
                     param: new
                     {
                        
                     },
                     commandType: CommandType.StoredProcedure);
            return model;
        }
    }
}
