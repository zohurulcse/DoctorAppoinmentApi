using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Purchase
{
    [Table("PhOpeningStockHead")]
    public class PhOpeningStockHead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(15)]      
        public string CustomCode { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime Date { get; set; }

        [StringLength(15)]
        [Required]        
        public int SupplierID { get; set; }

        [Display(Name = "Total Quantity")]
        public decimal? TotalQuantity { get; set; }

        [Display(Name = "Net Amount")]
        public decimal? NetAmount { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [StringLength(10)]
        [Required]
        public string Status { get; set; }

        [Required]
        public int ShopID { get; set; }

        [Required]
        public int InBy { get; set; }

        [StringLength(50)]
        public string InPC { get; set; }
        public int UpBy { get; set; }

        [StringLength(50)]
        public string UpPC { get; set; }

        public virtual List<PhOpeningStockDetails> PhOpeningStockDetails { get; set; }
    }
}
