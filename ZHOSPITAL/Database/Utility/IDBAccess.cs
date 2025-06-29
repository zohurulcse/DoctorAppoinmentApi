
using Microsoft.Data.SqlClient;

namespace ZHOSPITAL.Database.Utility
{
    public interface IDBAccess
    {
        SqlConnection GetConnection();
        SqlConnection GetPortalConnection();
        string GetAPIToken();
        string GetReportApi();
        string GetSMTPSentEmail();
        string GetAmrstockConnection();

        string GetCompanyShortCode();
        int GetSecUserID();

        string GetCTitle();

        //Task<int> GetStockID();

        string CreateToken(string email, string cellNo);
        //public Task<string> CodeGenerator(string prefix, string table, string columnname);
    }
}
