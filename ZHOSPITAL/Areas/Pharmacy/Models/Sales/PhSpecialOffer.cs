using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Sales
{
    [Table("PhSpecialOffer")]
    public class PhSpecialOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(15)]
        public string CustomCode { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Offer Type")]
        public string OfferType { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Offer Tittle")]
        public string OfferTittle { get; set; }

        [Required]
        public long ProductID { get; set; }

        [DefaultValue(0)]
        public decimal Discount { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        [StringLength(8)]
        public string Status { get; set; }

        [Required]
        public int ShopID { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }

        [Required]
        public int InBy { get; set; }

        [StringLength(50)]
        public string InPC { get; set; }
        public int UpBy { get; set; }

        [StringLength(50)]
        public string UpPC { get; set; }

        public virtual List<PhSpecialOfferDetails> PhSpecialOfferDetails { get; set; }

    }
}
