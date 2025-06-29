using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Issue
{
    [Table("PhIssueHead")]
    public class PhIssueHead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(15)]        
        public string CustomCode { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "Total Quantity")]
        public int? TotalQuantity { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [StringLength(10)]
        [Required]
        public string Status { get; set; }

        [StringLength(10)]
        [Required]
        public string ReceiveStatus { get; set; }

        [Required]
        public int ShopID { get; set; }

        [Required]
        public int ToShopID { get; set; }

        public virtual List<PhIssueDetails>  PhIssueDetails { get; set; }

    }
}
