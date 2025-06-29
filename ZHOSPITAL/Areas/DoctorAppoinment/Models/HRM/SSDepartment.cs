using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.VarietiesStore.Models.HRM
{
    [Table("SSDepartments")]
    public class SSDepartment
    {
        [Required, Key]
        [StringLength(15)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(8)]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Company")]
        public string CompanyCode { get; set; }
        [ForeignKey("CompanyCode")]
        public Company Company { get; set; }
    }
}
