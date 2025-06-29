using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup
{
    [Table("PhCategorys")]
    public class PhCategory
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
      
        public int ShopID { get; set; }        

        [StringLength(70)]
        public string Photo { get; set; }

        [NotMapped]
        public string itemName { get; set; }

        [NotMapped]
        public bool editable { get; set; }
    }
}
