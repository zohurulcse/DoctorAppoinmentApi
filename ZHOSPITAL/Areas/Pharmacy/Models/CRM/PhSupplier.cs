using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.CRM
{
    [Table("PhSuppliers")]
    public class PhSupplier
    {
        [Key]      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(15)]      
        public string CustomCode { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        [StringLength(150)]
        [Required]
        public string Address { get; set; }

        [StringLength(100)]
        [Required]
        public string MobileNumber { get; set; }

        [StringLength(100)]       
        public string Email { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

        [Required]
        public int ShopID { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }
    }
}
