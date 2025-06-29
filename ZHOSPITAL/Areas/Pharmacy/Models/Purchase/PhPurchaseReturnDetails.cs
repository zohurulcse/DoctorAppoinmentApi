using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Purchase
{
    [Table("PhPurchaseReturnDetails")]
    public class PhPurchaseReturnDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }        

        [ForeignKey("PurchaseReturnID")]
        public virtual PhPurchaseReturnHead PhPurchaseReturnHead { get; set; }

        [Required]
        public long ProductID { get; set; }

        [NotMapped]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]        
        public decimal Quantity { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]       
        public long PurchaseDetailID { get; set; }
    }
}
