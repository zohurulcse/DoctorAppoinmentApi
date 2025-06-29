using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;
using ZAPI.Areas.VarietiesStore.Models.Sales;

namespace ZAPI.Areas.VarietiesStore.Models.Inventory
{
    public class SSSetMenuSalesDetails
    {
        [Key]
        public int Id { get; set; }
        public string SalesDetailsCode { get; set; }
        [ForeignKey("SalesDetailsCode")]
        public virtual VSSalesDetails SalesDetails { get; set; }
        public string ProductCode { get; set; }

        [ForeignKey("ProductCode")]
        public virtual VSProduct Product { get; set; }
    }
}
