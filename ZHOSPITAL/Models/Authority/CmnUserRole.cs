using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZAPI.Areas.VarietiesStore.Models.Authority
{
    [Table("VSUserRoles")]
    public class CmnUserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

        //[StringLength(15)]
        [Required]
        //[Display(Name = "Shop")]
        public int ShopID { get; set; }

    }
}
