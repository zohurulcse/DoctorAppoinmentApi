using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Inventory
{
    [Table("PhInventoryDetails")]
    public class PhInventoryDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("InventoryID")]
        public virtual PhInventoryHead VSInventoryHead { get; set; }

        [Required]       
        public int ProductID { get; set; }

        [Required]
        [DefaultValue(0)]
        [Display(Name = "Stock Quantity")]
        public decimal StockQuantity { get; set; }

        [Required]
        [DefaultValue(0)]
        [Display(Name = "Inventory Quantity")]
        public decimal InventoryQuantity { get; set; }

        [Required]
        [DefaultValue(0)]
        [Display(Name = "Adjust Quantity")]
        public decimal AdjustQuantity { get; set; }
       
        [Required]      
        public int ShopID { get; set; }
    }
}
