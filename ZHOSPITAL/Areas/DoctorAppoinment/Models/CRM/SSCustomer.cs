using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Model;

namespace ZAPI.Areas.VarietiesStore.Models.CRM
{
    [Table("SSCustomers")]
    public class SSCustomer
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(100)]
        [Required]
        public string Contact { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string FatherName { get; set; }

        [StringLength(50)]
        public string ParaMoholla { get; set; }

        [StringLength(50)]
        public string Village { get; set; }

        [StringLength(20)]
        public string DivisionCode { get; set; }

        [StringLength(20)]
        public string DistrictCode { get; set; }

        [StringLength(20)]
        public string ThanaCode { get; set; }

        [StringLength(20)]
        [Required]
        public string UserID { get; set; }

        [StringLength(50)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? DateofBirth { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }

        [StringLength(20)]
        public string ShopCode { get; set; }
    }
}
