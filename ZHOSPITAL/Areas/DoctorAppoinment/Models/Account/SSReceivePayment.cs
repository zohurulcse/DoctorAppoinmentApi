using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.SupperShop.Models.Account
{
    [Table("SSReceivePayments")]
    public class SSReceivePayment
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }

        [StringLength(15)]
        [Required]
        public string ReferenceNo { get; set; }

        [StringLength(15)]
        [Required]
        public string InvoiceNo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime TransactionDate { get; set; }

        [Required]
        public int PaymentType { get; set; }

        [StringLength(15)]
        [Display(Name = "Bank")]
        public string BankCode { get; set; }

        [StringLength(30)]
        public string BankAccountNo { get; set; }

        [StringLength(30)]
        public string BankChequeNo { get; set; }

        public int PaymodeID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Company")]
        public string CompanyCode { get; set; }
        [ForeignKey("CompanyCode")]
        public Company Company { get; set; }
    }
}

