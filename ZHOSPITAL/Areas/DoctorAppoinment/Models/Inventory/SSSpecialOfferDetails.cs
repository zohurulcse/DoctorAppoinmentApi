using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Model;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;
using ZAPI.Areas.VarietiesStore.Models.Sales;

namespace ZAPI.Areas.VarietiesStore.Models.Inventory
{
    [Table("SSSpecialOfferDetails")]
    public class SSSpecialOfferDetails
    {
        [Key]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        public string HeadCode { get; set; }

        [Display(Name = "Special Offer")]
        [ForeignKey("HeadCode")]
        public virtual VSSpecialOffer SpecialOffer { get; set; }

        [Display(Name = "Product Name")]
        [Required]
        public string GetProductCode { get; set; }
        [ForeignKey("GetProductCode")]
        public virtual VSProduct GetProduct { get; set; }

        [Display(Name = "Quantity")]
        [Required]
        public decimal GetQuantity { get; set; }
    }
}
