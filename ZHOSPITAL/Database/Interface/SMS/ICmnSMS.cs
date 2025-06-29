using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Database.Interface.SMS
{
    public interface ICmnSMS
    {
        public bool MobileIsValid(string mobile);
        string SendSMS(string mobile,string message, string id);

        Task<bool> SendOTPSMS(string mobile, int otp);
    }
}
