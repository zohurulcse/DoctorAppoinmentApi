using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using ZAPI.Areas.VarietiesStore.Models.Authority;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.SupperShop.Models.Authority
{
    [Table("SSUsers")]
    [Index(nameof(Email), IsUnique = true)]
    public class SSUser
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [StringLength(200, ErrorMessage = "Must be between 6 and 20 characters", MinimumLength = 6)]
        [Required]
        public string Password { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Role")]
        public string RoleCode { get; set; }

        [ForeignKey("RoleCode")]
        public virtual VSUserRole UserRole { get; set; }

        [StringLength(15)]
        [Required]
        public string BranchCode { get; set; }

        [ForeignKey("BranchCode")]
        public Branch Branch { get; set; }

        [StringLength(1)]
        public string Counter { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }

        [StringLength(20)]
        public string ShopCode { get; set; }

        [StringLength(20)]
        public string CustomerCode { get; set; }

        [StringLength(20)]
        public string BazarOperatorCode { get; set; }

        public bool IsApproved { get; set; }
    }
}
