using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;

namespace ZAPI.Areas.VarietiesStore.Models.Inventory
{
    public class SSSalePrice
    {
        [Required]
        [Key]
        [Display(Name = "Product")]
        public string ProductCode { get; set; }
        [ForeignKey("ProductCode")]
        public virtual VSProduct Product { get; set; }

        [Display(Name = "Sales Price")]
        public decimal Price { get; set; }

        [DefaultValue(0.00)]
        [Display(Name = "Discount Amount")]
        public decimal DiscountAmount { get; set; }

        [Display(Name = "Discount Percent")]
        public decimal DiscountPercent { get; set; }
    }
}
