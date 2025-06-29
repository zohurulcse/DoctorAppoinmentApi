using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.SupperShop.Models.Authority
{
    [Table("SSUserRoles")]
    public class SSUserRole
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

        [StringLength(15)]
        [Required]
        public string CompanyCode { get; set; }
        [ForeignKey("CompanyCode")]
        public Company Company { get; set; }
    }
}
