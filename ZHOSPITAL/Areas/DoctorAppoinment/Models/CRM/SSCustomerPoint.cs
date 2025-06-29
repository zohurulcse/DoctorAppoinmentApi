using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Model;
using ZAPI.Areas.VarietiesStore.Models.CRM;
using ZAPI.Areas.VarietiesStore.Models.Sales;

namespace ZAPI.Areas.SupperShop.Models.CRM
{
    [Table("SSCustomerPoints")]
    public class SSCustomerPoint
    {
        [Required, Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [Required]
        public string CustomerCode { get; set; }
        [ForeignKey("CustomerCode")]
        public VSCustomer Customer { get; set; }

        [Required]
        public decimal ExpendAmount { get; set; }

        [Required]
        public decimal Point { get; set; }

        [Required]
        public string ReferenceCode { get; set; }
        [ForeignKey("ReferenceCode")]
        public virtual VSSalesHead SalesHead { get; set; }
    }
}
