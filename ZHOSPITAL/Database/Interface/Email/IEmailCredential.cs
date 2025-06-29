using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Database.Interface.Email
{
    public interface IEmailCredential
    {
        List<CmnEmailCredential> GetCmnEmailCredentials();
    }
}
