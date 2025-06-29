using System.ComponentModel.DataAnnotations;

namespace ZHOSPITAL.Models.ViewModel
{
    public class LoginModel
    {       
        public int UserID { get; set; }
       
        public int ShopID { get; set; }


        [StringLength(30)]
        public string UserName { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }

        [StringLength(20, ErrorMessage = "Must be between 6 and 20 characters", MinimumLength = 6)]
        public string Password { get; set; }

        [StringLength(6)]
        public string LoginType { get; set; }
        public string Token { get; set; }
    }
}
