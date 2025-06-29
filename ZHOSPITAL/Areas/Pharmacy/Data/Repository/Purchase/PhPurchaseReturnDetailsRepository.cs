using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Purchase;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Repository.Purchase
{
    public class PhPurchaseReturnDetailsRepository : BaseRepository<PhPurchaseReturnDetails>, IPhPurchaseReturnDetailsRepository
    {
        public PhPurchaseReturnDetailsRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        //public List<VSPurchaseReturnDetails> GetByHeadCode(string HeadCode)
        //{
        //    List<VSPurchaseReturnDetails> purchaseDetails = _db.VSPurchaseReturnDetails.Where(c => c.HeadCode == HeadCode).ToList();
        //    return purchaseDetails;
        //}
    }
}
