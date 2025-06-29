using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;

namespace DataAccessLayer.Model
{
    [Table("SSProductOrderDetails")]
    public class SSProductOrderDetail
    {
        [Required, Key]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        [StringLength(15)]
        public string HeadCode { get; set; }
        [ForeignKey("HeadCode")]
        public virtual VSProductOrder ProductOrder { get; set; }

        [StringLength(50)]
        [Required]
        public string ProductName { get; set; }

        [StringLength(70)]
        public string Photo { get; set; }

        [StringLength(13)]
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }

        [Required]
        [Display(Name = "Product")]
        [StringLength(15)]
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
        [StringLength(15)]
        public string ShopCode { get; set; }

        [StringLength(20)]
        [Required]        
        public string Status { get; set; }
    }
}
