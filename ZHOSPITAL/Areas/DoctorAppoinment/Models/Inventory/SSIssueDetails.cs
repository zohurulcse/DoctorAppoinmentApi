using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Model;
using ZAPI.Areas.VarietiesStore.Models.Issue;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;

namespace ZAPI.Areas.SupperShop.Models.Inventory
{
    [Table("SSIssueDetails")]
    public class SSIssueDetails
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }

        [StringLength(15)]
        [Required]
        public string HeadCode { get; set; }
        [ForeignKey("HeadCode")]
        public virtual VSIssueHead IssueHead { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Product")]
        public string ProductCode { get; set; }
        [ForeignKey("ProductCode")]
        public virtual VSProduct Product { get; set; }

        [Required]
        [Range(1, 99999)]
        public decimal Quantity { get; set; }

        [Display(Name = "SalecPrice")]
        [Required]
        public decimal SalePrice { get; set; }

        [Required]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
    }
}
