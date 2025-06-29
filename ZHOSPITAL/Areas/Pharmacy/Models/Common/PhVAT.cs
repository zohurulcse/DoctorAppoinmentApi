using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Common
{
    [Table("PhVATs")]
    public class PhVAT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 ID { get; set; }
       
        [Display(Name = "VAT (%)")]
        public decimal VATPercent { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Shop")]
        public string ShopID { get; set; }
    }
}
