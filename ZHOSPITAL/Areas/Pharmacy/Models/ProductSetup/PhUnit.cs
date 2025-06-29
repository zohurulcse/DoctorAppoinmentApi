using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup
{
    [Table("PhUnits")]
    public class PhUnit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 ID { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

        [Required]
        public int ShopID { get; set; }
    }
}
