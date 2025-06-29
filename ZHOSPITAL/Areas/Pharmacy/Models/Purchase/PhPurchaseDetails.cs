using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Purchase
{
    [Table("PhPurchaseDetails")]
    public class PhPurchaseDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }       
        
        [ForeignKey("PurchaseID")]
        public virtual PhPurchaseHead PhPurchaseHead { get; set; }       
       
        [Required]      
        public long ProductID { get; set; }
        [NotMapped]
        public string ProductName { get; set; }

        //[ForeignKey("ProductID")]
        //public virtual VSProduct VSProduct { get; set; }


        [Required(ErrorMessage = "Quantity is Required")]
        [Range(0, 99999)]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "CostPrice is Required")]
        public decimal CostPrice { get; set; }

        [Required(ErrorMessage = "TotalAmount is Required")]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage ="SalePrice is Required")]
        [Display(Name = "Sales Price")]
        public decimal SalesPrice { get; set; }

        [StringLength(20)]
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }
              
        public byte[] BarcodeImage { get; set; }

        [StringLength(13)]
        [Display(Name = "Packet Barcode")]
        public string PacketBarcode { get; set; }

        [Display(Name = "Expired Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? ExapiredDate { get; set; }
    }
}
