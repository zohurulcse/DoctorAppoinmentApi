using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Model;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;

namespace ZAPI.Areas.VarietiesStore.Models.Sales
{
    [Table("SSSaleReturnDetails")]
    public class SSSaleReturnDetails
    {
        [Required, Key]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        public string HeadCode { get; set; }
        [ForeignKey("HeadCode")]
        public virtual VSSaleReturnHead SaleReturnHead { get; set; }

        [Required]
        public string ProductCode { get; set; }
        [ForeignKey("ProductCode")]
        public virtual VSProduct Product { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        //[System.Web.Mvc.Remote("CheckQuantity", "SaleReturn", AdditionalFields = "Code", HttpMethod ="POST", ErrorMessage = "Return Qty Grater Than Sale Qty !")]
        public decimal Quantity { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(15)]
        public string ReferenceCode { get; set; }
        [ForeignKey("ReferenceCode")]
        public virtual VSSalesDetails SalesDetails { get; set; }
    }
}
