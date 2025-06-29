using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Sales
{
    [Table("PhSpecialOfferDetails")]
    public class PhSpecialOfferDetails
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("SpecialOfferID")]
        public virtual PhSpecialOffer VSSpecialOffer { get; set; }

        [Required]
        public long ProductID { get; set; }

        [Display(Name = "Quantity")]
        [Required]
        public decimal Quantity { get; set; }
    }
}
