using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup
{
    [Table("PhColor")]
    public class PhColor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 ID { get; set; }

        [StringLength(50)]
        [Required]
        public string ColorName { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }
        
        [Required]       
        public int ShopID { get; set; }              
    }
}
