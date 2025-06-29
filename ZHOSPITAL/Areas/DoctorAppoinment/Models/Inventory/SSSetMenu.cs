using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Model;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;

namespace ZAPI.Areas.VarietiesStore.Models.Inventory
{
    [Table("SSSetMenu")]
    public class SSSetMenu
    {
        [Key]
        public int Id { get; set; }

        [StringLength(15)]
        [Required]
        public string ProductCode { get; set; }
        [ForeignKey("ProductCode")]
        public virtual VSProduct Product { get; set; }

        [StringLength(15)]
        [Required]
        public string SubProductCode { get; set; }
        [ForeignKey("SubProductCode")]
        public virtual VSProduct SubProduct { get; set; }

        public decimal Quantity { get; set; }
    }
}
