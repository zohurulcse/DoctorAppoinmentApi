namespace ZHOSPITAL.Database.Interface.Authority
{
    public interface ISystemSecurity
    {
        public Task<int> Permission(int shopID,int roleID,int userID,string Url, string Action,string apiMethod);
        public string Encrypt(string clearText);
        public string Decrypt(string cipherText);
        public string CreateToken(string userID, string email, string mobile);
    }
}
