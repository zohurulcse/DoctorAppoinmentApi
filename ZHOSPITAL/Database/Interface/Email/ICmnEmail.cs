using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Database.Interface.Email
{
    public interface ICmnEmail
    {
        public bool EmailIsValid(string email);
        Task<bool> SendMail(CmnEmailCredential cmnEmailCredential);

        Task<bool> SendOTPMail(string email, int otp, CmnEmailCredential cmnEmailCredential);
    }
}
