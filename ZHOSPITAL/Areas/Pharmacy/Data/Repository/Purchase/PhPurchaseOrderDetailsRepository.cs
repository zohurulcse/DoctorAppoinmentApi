
using System;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Purchase;
using ZHOSPITAL.Areas.Pharmacy.Models.Inventory;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Repository.Purchase
{
    public class PhPurchaseOrderDetailsRepository : BaseRepository<PhPurchaseOrderDetails>, IPhPurchaseOrderDetailsRepository
    {
        public PhPurchaseOrderDetailsRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<PhPurchaseOrderDetails> GetAll()
        {
            List<PhPurchaseOrderDetails> purchaseDetails = new List<PhPurchaseOrderDetails>();
            try
            {
                purchaseDetails = _db.PhPurchaseOrderDetails.ToList();
            }
            catch (Exception ex) { }
            return purchaseDetails;
        }

        //public List<PurchaseOrderDetails> GetAll(string searchValue)
        //{
        //    List<PurchaseOrderDetails> purchaseDetails = _db.PurchaseOrderDetails.Where(c => c.Barcode == searchValue).ToList();
        //    return purchaseDetails;
        //}
        //public List<VSPurchaseOrderDetails> GetByHeadCode(string HeadCode)
        //{
        //    List<VSPurchaseOrderDetails> purchaseDetails = _db.VSPurchaseOrderDetails.Where(c => c.HeadCode == HeadCode).ToList();
        //    return purchaseDetails;
        //}
        //public List<VSPurchaseOrderDetails> GetByHeadDetailsCode(string HeadCode, string DetailsCode)
        //{
        //    List<VSPurchaseOrderDetails> purchaseDetails = _db.VSPurchaseOrderDetails.Where(c => c.HeadCode == HeadCode && c.Code == DetailsCode).ToList();
        //    return purchaseDetails;
        //}

    }
}
