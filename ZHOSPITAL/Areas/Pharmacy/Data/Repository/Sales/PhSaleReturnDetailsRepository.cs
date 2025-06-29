using ZHOSPITAL.Areas.Pharmacy.Models.Sales;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhSaleReturnDetailsRepository : BaseRepository<PhSaleReturnDetails>, IPhSaleReturnDetailsRepository
    {
        public PhSaleReturnDetailsRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        //public List<VSSaleReturnDetails> GetByHeadCode(string HeadCode)
        //{
        //    List<VSSaleReturnDetails> saleReturnDetails = _db.VSSaleReturnDetails.Where(c => c.HeadCode == HeadCode).ToList();
        //    return saleReturnDetails;
        //}
        public decimal ProductSalesReturnQty(string SalesReturnDetailsCode, string ProductCode)
        {
            //VSSaleReturnDetailsRepository _saleReturnDetailsRepository = new VSSaleReturnDetailsRepository();
            //var SalesReturnQty = _saleReturnDetailsRepository.GetAll().Where(x => x.ReferenceCode == SalesReturnDetailsCode && x.ProductCode == ProductCode).Select(s => s.Quantity).Sum();
            return 0;
        }
    }
}
