using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Interface.Purchase
{
    public interface IPhPurchaseReturnHeadRepository : IBaseRepository<PhPurchaseReturnHead>
    {
        public List<PhPurchaseReturnHead> GetDataByShop(int shopID, string approvedStatus);
        ////public bool Add(VSPurchaseReturnHead purchaseReturnHead, List<VSPurchaseReturnDetails> purchaseReturnDetailses);
        public int SavePurchaseReturn(PhPurchaseReturnHead purchaseReturnHead);
    }
}
