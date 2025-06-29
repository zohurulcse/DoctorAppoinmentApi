using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Model;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;

namespace ZAPI.Areas.VarietiesStore.Models.Sales
{
    [Table("SSSalesDetails")]
    public class SSSalesDetails
    {
        [Required, Key]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        public string HeadCode { get; set; }
        [ForeignKey("HeadCode")]
        public virtual VSSalesHead SalesHead { get; set; }

        [StringLength(13)]
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }

        [Required]
        [Display(Name = "Product")]
        public string ProductCode { get; set; }
        [ForeignKey("ProductCode")]
        public virtual VSProduct Product { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [DefaultValue(1)]
        public decimal Quantity { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Amount { get; set; }


        [DefaultValue(0)]
        [Display(Name = "Discount(%)")]
        public decimal? DiscountPercent { get; set; }

        [DefaultValue(0)]
        [Display(Name = "Discount(tk)")]
        public decimal? Discount { get; set; }

        [Required]
        [StringLength(8)]
        public string Status { get; set; }
    }
}
