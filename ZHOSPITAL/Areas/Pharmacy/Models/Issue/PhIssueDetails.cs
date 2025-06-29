using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Issue
{
    [Table("PhIssueDetails")]
    public class PhIssueDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("IssueID")]
        public virtual PhIssueHead VSIssueHead { get; set; }
       
        [Required]
        public int ProductID { get; set; }

        [Required]
        [Range(1, 99999)]
        public decimal Quantity { get; set; }

        [Display(Name = "SalecPrice")]
        [Required]
        public decimal SalePrice { get; set; }

        [Required]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Required]
        public int ShopID { get; set; }
    }
}
