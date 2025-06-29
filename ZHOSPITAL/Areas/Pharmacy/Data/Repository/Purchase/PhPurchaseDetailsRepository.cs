using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Purchase;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Repository.Purchase
{
    public class PhPurchaseDetailsRepository : BaseRepository<PhPurchaseDetails>, IPhPurchaseDetailsRepository
    {
        public PhPurchaseDetailsRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<PhPurchaseDetails> GetAll()
        {
            List<PhPurchaseDetails> purchaseDetails = new List<PhPurchaseDetails>();
            try
            {
                purchaseDetails = _db.PhPurchaseDetails.ToList();
            }
            catch (Exception ex) { }
            return purchaseDetails;
        }

        public List<PhPurchaseDetails> GetAll(string searchValue)
        {
            List<PhPurchaseDetails> purchaseDetails = _db.PhPurchaseDetails.Where(c => c.Barcode == searchValue).ToList();
            return purchaseDetails;
        }
        public List<PhPurchaseDetails> GetByHeadCode(int purchaseID)
        {
            List<PhPurchaseDetails> purchaseDetails = _db.PhPurchaseDetails.Where(c => c.PhPurchaseHead.ID == purchaseID).ToList();
            return purchaseDetails;
        }
        //public List<VSPurchaseDetails> GetByHeadDetailsCode(string HeadCode, string DetailsCode)
        //{
        //    List<VSPurchaseDetails> purchaseDetails = _db.VSPurchaseDetails.Where(c => c.HeadCode == HeadCode && c.Code == DetailsCode).ToList();
        //    return purchaseDetails;
        //}
        //public List<VSPurchaseDetails> GetByHeadProductCode(string HeadCode, string ProductCode)
        //{
        //    List<VSPurchaseDetails> purchaseDetails = _db.VSPurchaseDetails.Where(c => c.HeadCode == HeadCode && c.ProductCode == ProductCode).ToList();
        //    return purchaseDetails;
        //}
        public List<PhPurchaseDetails> GetByProductCode(int ProductID)
        {
            List<PhPurchaseDetails> purchaseDetails = _db.PhPurchaseDetails.Where(c => c.ProductID == ProductID).ToList();
            return purchaseDetails;
        }

    }
}
