using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Areas.Pharmacy.ViewModel;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Interface.Purchase
{
    public interface IPhPurchaseHeadRepository : IBaseRepository<PhPurchaseHead>
    {
        List<PhPurchaseVM> GetProductDetails(int ProductID, int ShopID);
        Task<List<PhPurchaseHead>> GetAllPurchaseCustomCode(int shopID, string type);
        public List<PhPurchaseHead> GetDataByShop(int ShopID,string approvedStatus);
        public string Approve(string @Code, string BranchCode);
        public int SavePurchase(PhPurchaseHead purchaseHead);
    }
}
