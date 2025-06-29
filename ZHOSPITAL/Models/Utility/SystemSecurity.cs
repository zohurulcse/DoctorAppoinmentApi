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
using DataAccessLayer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ZAPI.Models.Utility
{
    public class SystemSecurity
    {
        public readonly ZAPIDbContext _db;
        public string Permission(string Url, string Action)
        {
            string result = "Somethingiswrong";
            try
            {
                Url = Url.Replace("/Edit", "/Add");
                if ("ROL000000000000" == null)//HttpContext.Current.Session["RoleCode"]
                {
                    return result = "SessionOut";
                }
                string RoleCode = "ROL000000000000";
                SqlParameter[] sqlParameters ={
                    new SqlParameter
                    {
                        ParameterName = "@RoleCode",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = RoleCode,
                        Size=15
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Url",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = Url,
                        Size=150
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Action",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = Action,
                        Size=6
                    }
                };

                bool status = _db.Database.SqlQueryRaw<bool>("SP_CheckRolePermission @RoleCode,@Url,@Action", sqlParameters).FirstOrDefault();
                if (status)
                {
                    result = "True";
                }
                else
                {
                    result = "InsufficientPermissions";
                }
            }
            catch (Exception ex) { }
            return result;
        }

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
    }
}
