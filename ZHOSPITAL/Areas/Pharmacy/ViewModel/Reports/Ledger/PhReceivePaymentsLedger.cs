namespace ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports.Ledger
{
    public class PhReceivePaymentsLedger
    {
        public string LedgerCode { get; set; }
        public string SupplierName { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ReceivePaymentType { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string ShopEmail { get; set; }
        public string ShopMobileNumber { get; set; }
        public string Remarks { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public decimal? ReceiveAmount { get; set; }
        public decimal? PaymentAmount { get; set; }
        public decimal? OpeningBalance { get; set; }
    }
}
