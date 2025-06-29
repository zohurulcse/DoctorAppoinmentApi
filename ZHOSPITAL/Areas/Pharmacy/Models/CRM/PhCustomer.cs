using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.CRM
{
    [Table("PhCustomers")]
    public class PhCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(15)]    
        public string CustomCode { get; set; }

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
       
        public Int16 DivisionID { get; set; }
       
        public Int16 DistrictID { get; set; }
      
        public Int16 ThanaID { get; set; }
       
        [Required]
        public int UserID { get; set; }

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
       
        [Required]        
        public int ShopID { get; set; }
    }
}
