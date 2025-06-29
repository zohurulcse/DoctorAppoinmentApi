using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.SupperShop.Models.Inventory
{
    [Table("SSColor")]
    public class SSColor
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }

        [StringLength(50)]
        [Required]
        public string ColorName { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Company")]
        public string CompanyCode { get; set; }
        [ForeignKey("CompanyCode")]
        public Company Company { get; set; }
    }
}
