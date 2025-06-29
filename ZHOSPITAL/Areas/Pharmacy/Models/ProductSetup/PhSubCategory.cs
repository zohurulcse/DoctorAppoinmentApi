using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup
{
    [Table("PhSubCategorys")]
    public class PhSubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 ID { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        public Int16 CategoryID { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

        [Required]
        public int ShopID { get; set; }

        [StringLength(70)]
        public string Photo { get; set; }
    }
}
