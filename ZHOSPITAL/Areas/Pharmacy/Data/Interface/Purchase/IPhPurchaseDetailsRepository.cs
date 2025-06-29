using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Interface.Purchase
{
    public interface IPhPurchaseDetailsRepository : IBaseRepository<PhPurchaseDetails>
    {
        public List<PhPurchaseDetails> GetByHeadCode(int purchaseID);
        //public List<VSPurchaseDetails> GetByHeadDetailsCode(string HeadCode, string DetailsCode);
        //public List<VSPurchaseDetails> GetByHeadProductCode(string HeadCode, string ProductCode);
        public List<PhPurchaseDetails> GetByProductCode(int ProductCode);
    }
}
