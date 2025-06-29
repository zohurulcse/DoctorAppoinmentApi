using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ZHOSPITAL.Database.Utility
{
    public static class GenUtility
    {
        public static string GetEncryptedText(string InputString)
        {
            string senc = "";
            try
            {
                string smsg = InputString;
                var utf = new UTF8Encoding();
                byte[] key = utf.GetBytes("12348765");
                byte[] iv = { 1, 2, 3, 4, 8, 7, 6, 5 };
                ICryptoTransform encryptor = new DESCryptoServiceProvider().CreateEncryptor(key, iv);

                byte[] bmsg = utf.GetBytes(smsg);
                byte[] benc = encryptor.TransformFinalBlock(bmsg, 0, bmsg.Length);
                senc = System.Convert.ToBase64String(benc);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return senc;
        }

        public static string GetDecryptedText(string EncryptedString)
        {
            string sdec = "";
            try
            {
                string smsg = EncryptedString;
                var des = new DESCryptoServiceProvider();
                var utf = new UTF8Encoding();
                byte[] key = utf.GetBytes("12348765");
                byte[] iv = { 1, 2, 3, 4, 8, 7, 6, 5 };

                ICryptoTransform decryptor = des.CreateDecryptor(key, iv);
                byte[] bmsg = utf.GetBytes(smsg);
                byte[] benc1 = System.Convert.FromBase64String(EncryptedString);
                byte[] bdec = decryptor.TransformFinalBlock(benc1, 0, benc1.Length);
                sdec = utf.GetString(bdec);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return sdec;
        }
        public static string Serialize(SqlDataReader reader)
        {
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));

            return JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
        }
        private static Dictionary<string, object> SerializeRow(IEnumerable<string> cols, SqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
                result.Add(col, reader[col]);
            return result;
        }
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }
        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
