using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace ZHOSPITAL.Models.Authority
{
    [Table("CmnUsers")]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(MobileNumber), IsUnique = true)]
    public class CmnUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }     

        [StringLength(50, ErrorMessage = "Max Length Over 50")]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]        
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(15, ErrorMessage = "Enter Valid Mobile Number", MinimumLength = 11)]
        [Required]       
        public string MobileNumber { get; set; }

        [StringLength(200, ErrorMessage = "Must be between 6 and 20 characters", MinimumLength = 6)]
        [Required]
        public string Password { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

       
        [Required]
        public Int16 RoleID { get; set; }

        [StringLength(1)]
        public string Counter { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }
       
        public int CustomerID { get; set; }

        public int BazarOperatorID { get; set; }

        public bool IsApproved { get; set; }

        [StringLength(6)]
        [NotMapped]
        public string LoginType { get; set; }

        [NotMapped]
        public string Token { get; set; }

        [Required]       
        public int ShopID { get; set; }       
    }
}
