using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Sales
{
    [Table("PhSalesDetails")]
    public class PhSalesDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [ForeignKey("SaleID")]
        public virtual PhSalesHead PhSalesHead { get; set; }

        [StringLength(20)]       
        public string Barcode { get; set; }

        [Required]
        public long ProductID { get; set; }

        [NotMapped]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [DefaultValue(1)]
        public decimal Quantity { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Amount { get; set; }


        [DefaultValue(0)]
        [Display(Name = "Discount(%)")]
        public decimal? DiscountPercent { get; set; }

        [DefaultValue(0)]
        [Display(Name = "Discount(tk)")]
        public decimal? Discount { get; set; }
       
        [StringLength(8)]
        public string Status { get; set; }
    }
}
