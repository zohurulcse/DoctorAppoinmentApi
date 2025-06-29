using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Sales
{
    [Table("PhSaleReturnDetails")]
    public class PhSaleReturnDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [ForeignKey("SaleReturnID")]
        public virtual PhSaleReturnHead PhSaleReturnHead { get; set; }

        [Required]
        public long ProductID { get; set; }

        [NotMapped]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]        
        public decimal Quantity { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]       
        public long SaleDetailID { get; set; }
    }
}
