using ZHOSPITAL.Areas.Pharmacy.Models.Sales;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public interface IPhSalesHeadRepository : IBaseRepository<PhSalesHead>
    {
        public int SaveSale(PhSalesHead salesHead);
        public IList<PhSalesHead> GetDataByShop(int shopID,string approvedStatus);
    }
}
