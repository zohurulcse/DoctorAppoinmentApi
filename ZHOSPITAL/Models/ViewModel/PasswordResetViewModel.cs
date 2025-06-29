using System.ComponentModel.DataAnnotations;

namespace ZHOSPITAL.Models.ViewModel
{
    public class PasswordResetViewModel
    {

        [StringLength(6)]
        public string LoginType { get; set; }

        [StringLength(30)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string CurrentPassword { get; set; }
        [StringLength(20)]
        public string NewPassword { get; set; }

        [StringLength(20)]
        public string ConfirmPassword { get; set; }
       

  
    }
}
