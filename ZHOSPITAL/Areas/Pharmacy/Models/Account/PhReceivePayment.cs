using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Account
{
    [Table("PhReceivePayments")]
    public class PhReceivePayment
    {
        [Key]
        [StringLength(15, ErrorMessage = "Max Length Over 15")]
        [Required]
        public string Code { get; set; }

        [StringLength(15, ErrorMessage = "Max Length Over 15")]
        [Required]
        public string LedgerCode { get; set; }

        [StringLength(15, ErrorMessage = "Max Length Over 15")]
        [Required]
        public string InvoiceNo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime TransactionDate { get; set; }

        [Required]
        public int PaymentType { get; set; }

        [StringLength(15, ErrorMessage = "Max Length Over 15")]
        [Display(Name = "Bank")]
        public string BankCode { get; set; }

        [StringLength(30, ErrorMessage = "Max Length Over 30")]
        public string BankAccountNo { get; set; }

        [StringLength(30, ErrorMessage = "Max Length Over 30")]
        public string BankChequeNo { get; set; }

        public int PaymodeID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [StringLength(500, ErrorMessage = "Max Length Over 500")]
        public string Remarks { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }

        public int ShopID { get; set; }

        [Required]
        public int InBy { get; set; }

        [StringLength(50)]
        public string InPC { get; set; }
        public int UpBy { get; set; }

        [StringLength(50)]
        public string UpPC { get; set; }
    }
}

