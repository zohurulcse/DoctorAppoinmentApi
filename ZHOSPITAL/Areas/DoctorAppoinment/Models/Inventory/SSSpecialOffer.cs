using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.VarietiesStore.Models.Inventory
{
    [Table("SSSpecialOffer")]
    public class SSSpecialOffer
    {
        [Key]
        [Required]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Offer Type")]
        public string OfferType { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Offer Tittle")]
        public string OfferTittle { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductCode { get; set; }
        [ForeignKey("ProductCode")]
        public virtual VSProduct Product { get; set; }

        [DefaultValue(0)]
        public decimal Discount { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        [StringLength(8)]
        public string Status { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Branch")]
        public string BranchCode { get; set; }

        [ForeignKey("BranchCode")]
        public virtual Branch Branch { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }
    }
}
