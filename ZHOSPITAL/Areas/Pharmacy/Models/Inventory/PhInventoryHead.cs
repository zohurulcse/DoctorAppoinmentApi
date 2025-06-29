using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Inventory
{
    [Table("PhInventoryHead")]
    public class PhInventoryHead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(15)]
        public string CustomCode { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd-MMM-yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd-MMM-yyyy}")]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [Required]
        [DefaultValue(0)]
        [Display(Name = "Stock Quantity")]
        public decimal TotalStockQuantity { get; set; }

        [Required]
        [DefaultValue(0)]
        [Display(Name = "Inventory Quantity")]
        public decimal TotalInventoryQuantity { get; set; }

        [Required]
        [DefaultValue(0)]
        [Display(Name = "Adjust Quantity")]
        public decimal TotalAdjustQuantity { get; set; }

        [Required]
        [StringLength(8)]
        public string Status { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }

        [Required]
        public int ShopID { get; set; }

        [Required]
        public int InBy { get; set; }

        [StringLength(50)]
        public string InPC { get; set; }
        public int UpBy { get; set; }

        [StringLength(50)]
        public string UpPC { get; set; }

        public virtual List<PhInventoryDetails> PhInventoryDetails { get; set; }

    }
}
