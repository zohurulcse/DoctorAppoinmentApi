using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Model;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;
using ZAPI.Areas.VarietiesStore.Models.Purchase;

namespace ZAPI.Areas.SupperShop.Models.Inventory
{
    [Table("SSPurchaseDetails")]
    public class SSPurchaseDetails
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }

        [StringLength(15)]
        [Required]
        public string HeadCode { get; set; }

        [ForeignKey("HeadCode")]
        public virtual VSPurchaseHead PurchaseHead { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Product")]
        public string ProductCode { get; set; }
        [ForeignKey("ProductCode")]
        public virtual VSProduct Product { get; set; }

        [StringLength(500)]
        public string ProductName { get; set; }

        [StringLength(70)]
        public string ProductPhoto { get; set; }

        //[Required]
        [Range(0, 99999)]
        public decimal Quantity { get; set; }

        //[Required]
        public decimal CostPrice { get; set; }

        //[Required]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        //[Required]
        [Display(Name = "Sales Price")]
        //[Remote("CheckSalesPrice", "Purchase", AdditionalFields = "CostPrice", ErrorMessage = "Sale Price Grater Than Cost Price !")]
        public decimal SalesPrice { get; set; }

        //[StringLength(15)]
        //[Display(Name = "Size")]
        //public string SizeCode { get; set; }
        //[ForeignKey("SizeCode")]
        //public virtual Size Size { get; set; }

        //[StringLength(20)]
        //public string Color { get; set; }

        [StringLength(13)]
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }

        [Column(TypeName = "image")]
        public byte[] BarcodeImage { get; set; }

        [StringLength(13)]
        [Display(Name = "Packet Barcode")]
        public string PacketBarcode { get; set; }

        [Display(Name = "Expired Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? ExapiredDate { get; set; }
    }
}
