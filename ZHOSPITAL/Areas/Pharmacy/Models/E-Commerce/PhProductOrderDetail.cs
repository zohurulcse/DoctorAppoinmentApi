using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ZHOSPITAL.Areas.Pharmacy.Models
{
    [Table("PhProductOrderDetails")]
    public class PhProductOrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [ForeignKey("ProductOrderID")]
        public virtual PhProductOrder VSProductOrder { get; set; }


        [StringLength(15,ErrorMessage ="Max Length Over 15")]
        public string CustomCode { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Max Length Over 15")]
        public string HeadCode { get; set; }
       
        [StringLength(50, ErrorMessage = "Max Length Over  50")]
        [Required]
        public string ProductName { get; set; }

        [StringLength(70, ErrorMessage = "Max Length Over 70")]
        public string Photo { get; set; }

        [StringLength(13, ErrorMessage = "Max Length Over 13")]
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }

        [Required]       
        public string ProductID { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [DefaultValue(1)]
        public decimal Quantity { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Amount { get; set; }


        [DefaultValue(0)]      
        public decimal? DiscountPercent { get; set; }

        [DefaultValue(0)]      
        public decimal? Discount { get; set; }

        [Required]
        public string ShopID { get; set; }
      

        [StringLength(20)]
        [Required]        
        public string Status { get; set; }
    }
}
