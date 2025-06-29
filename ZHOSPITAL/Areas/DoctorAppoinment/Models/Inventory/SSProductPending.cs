using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Areas.VarietiesStore.Models.CRM;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.SupperShop.Models.Inventory
{
    [Table("SSProductsPending")]
    public class SSProductPending
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }

        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        [StringLength(15)]
        [Display(Name = "Group")]
        public string GroupCode { get; set; }
        [ForeignKey("GroupCode")]
        public virtual VSGroup Group { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Category")]
        public string CategoryCode { get; set; }
        [ForeignKey("CategoryCode")]
        public virtual VSCategory Category { get; set; }

        [Display(Name = "Brand")]
        [StringLength(15)]
        public string BrandCode { get; set; }
        [ForeignKey("BrandCode")]

        public virtual VSBrand Brand { get; set; }

        [Display(Name = "Style")]
        [StringLength(15)]
        public string StyleCode { get; set; }
        [ForeignKey("StyleCode")]

        public virtual VSStyle Style { get; set; }

        [StringLength(15)]
        [Display(Name = "Size")]
        public string SizeCode { get; set; }
        [ForeignKey("SizeCode")]
        public virtual VSSize Size { get; set; }

        [StringLength(20)]
        public string Color { get; set; }

        [Display(Name = "Product Unit")]
        [StringLength(15)]
        public string UnitCode { get; set; }
        [ForeignKey("UnitCode")]
        public virtual VSUnit Unit { get; set; }

        [StringLength(70)]
        public string Photo { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

        //[Display(Name ="Re-Order Level")]
        public int? ReOrderLevel { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Company")]
        public string CompanyCode { get; set; }
        [ForeignKey("CompanyCode")]
        public virtual Company Company { get; set; }

        [Display(Name = "Current Stock")]
        [DefaultValue(0)]
        public decimal? CurrentStock { get; set; }

        [Display(Name = "Cost Price")]
        [DefaultValue(0.00)]
        public decimal? CostPrice { get; set; }

        [Display(Name = "Sale Price")]
        [DefaultValue(0.00)]
        public decimal? SalePrice { get; set; }


        [Display(Name = "VAT")]
        [DefaultValue(0.00)]
        public decimal VAT { get; set; }

        [Display(Name = "TAX")]
        [DefaultValue(0.00)]
        public decimal TAX { get; set; }

        [Display(Name = "Supplier Name")]
        [StringLength(15)]
        public string SupplierCode { get; set; }
        [ForeignKey("SupplierCode")]
        public virtual VSSupplier Supplier { get; set; }

        [StringLength(15)]
        [Display(Name = "Shop Type")]
        public string ShopTypeCode { get; set; }

        [StringLength(15)]
        [Display(Name = "Shop Name")]
        public string ShopCode { get; set; }

        [StringLength(15)]
        [Display(Name = "Division Name")]
        public string DivisionCode { get; set; }

        [StringLength(15)]
        [Display(Name = "District Name")]
        public string DistrictCode { get; set; }

        [StringLength(15)]
        [Display(Name = "Thana Name")]
        public string ThanaCode { get; set; }

        [StringLength(15)]
        [Display(Name = "Bazar Name")]
        public string BazarCode { get; set; }

        [StringLength(29)]
        public string SKU { get; set; }

        public bool? IsOnline { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }
    }
}
