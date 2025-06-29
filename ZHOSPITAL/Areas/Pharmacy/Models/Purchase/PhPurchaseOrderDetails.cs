using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Purchase
{
    [Table("PhPurchaseOrderDetails")]
    public class PhPurchaseOrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("PurchaseOrderID")]
        public virtual PhPurchaseOrderHead PhPurchaseOrderHead { get; set; }
      
        [Required]       
        public long ProductID { get; set; }

        [Required]
        [Range(1, 99999)]
        public decimal Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]       
        public decimal TotalPrice { get; set; }

   
    }
}
