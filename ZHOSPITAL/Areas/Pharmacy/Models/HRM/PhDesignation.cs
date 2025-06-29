using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.HRM
{
    [Table("PhDesignations")]
    public class PhDesignation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(8)]
        public string Status { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "ShopCode")]
        public string ShopCode { get; set; }
        //[ForeignKey("ShopCode")]
        //public virtual VSShopSetup VSShopSetup { get; set; }
    }
}
