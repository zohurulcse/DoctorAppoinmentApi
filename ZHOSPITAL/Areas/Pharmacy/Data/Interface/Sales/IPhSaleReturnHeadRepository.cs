using ZHOSPITAL.Areas.Pharmacy.Models.Sales;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public interface IPhSaleReturnHeadRepository : IBaseRepository<PhSaleReturnHead>
    {
        public IList<PhSaleReturnHead> GetDataByShop(int shopID, string approvedStatus);
    }
}
