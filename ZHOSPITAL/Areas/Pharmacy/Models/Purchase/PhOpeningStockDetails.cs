using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Purchase
{
    [Table("PhOpeningStockDetails")]
    public class PhOpeningStockDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("OpeningStockID")]
        public virtual PhOpeningStockHead PhOpeningStockHead { get; set; }

        [StringLength(15)]
        public string CustomCode { get; set; }

        [Required]
        public long ProductID { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Amount { get; set; }
    }
}
