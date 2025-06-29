using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.VarietiesStore.Models.CRM
{
    [Table("SSPoints")]
    public class SSPoints
    {
        [Required, Key]
        public string BranchCode { get; set; }
        [ForeignKey("BranchCode")]
        public virtual Branch Branch { get; set; }

        [Required]
        [Range(0.1, 9999.00, ErrorMessage = "The Value Range is 0.5 9999")]
        public decimal Expend { get; set; }

        [Required]
        [Range(0.1, 999.00, ErrorMessage = "The Value Range is 0.5 9999")]
        public decimal Point { get; set; }

        [Required]
        [Range(0.1, 9999.00, ErrorMessage = "The Value Range is 0.5 9999")]
        [Display(Name = "Point Value")]
        public decimal PointValue { get; set; }
    }
}
