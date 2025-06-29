using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.VarietiesStore.Models.Inventory
{
    [Table("SSStyles")]
    public class SSStyle
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(15)]
        public string ShopCode { get; set; }

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
