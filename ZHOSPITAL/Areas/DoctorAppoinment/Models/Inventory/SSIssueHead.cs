using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.SupperShop.Models.Inventory
{
    [Table("SSIssueHead")]
    public class SSIssueHead
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        [Required]
        public DateTime Date { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Destination")]
        public string DestinationBranchCode { get; set; }
        [ForeignKey("DestinationBranchCode")]
        public virtual Branch DestinationBranch { get; set; }

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

        [StringLength(15)]
        [Required]
        [Display(Name = "Source Branch")]
        public string BranchCode { get; set; }
        [ForeignKey("BranchCode")]
        public virtual Branch SourceBranch { get; set; }

    }
}
