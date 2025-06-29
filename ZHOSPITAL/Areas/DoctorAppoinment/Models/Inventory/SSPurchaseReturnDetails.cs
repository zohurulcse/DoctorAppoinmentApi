using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Model;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;
using ZAPI.Areas.VarietiesStore.Models.Purchase;

namespace ZAPI.Areas.VarietiesStore.Models.Inventory
{
    [Table("SSPurchaseReturnDetails")]
    public class SSPurchaseReturnDetails
    {
        [Required, Key]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        public string HeadCode { get; set; }
        [ForeignKey("HeadCode")]
        public virtual VSPurchaseReturnHead PurchaseReturnHead { get; set; }

        [Required]
        public string ProductCode { get; set; }
        [ForeignKey("ProductCode")]
        public virtual VSProduct Product { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        //[System.Web.Mvc.Remote("CheckQuantity", "PurchaseReturn", AdditionalFields = "Code", HttpMethod ="POST", ErrorMessage = "Return Qty Grater Than Purchase Qty !")]
        public decimal Quantity { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(15)]
        public string ReferenceCode { get; set; }
        [ForeignKey("ReferenceCode")]
        public virtual VSPurchaseDetails PurchaseDetails { get; set; }
    }
}
