using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup
{
    public interface IPhSubCategoryRepository : IBaseRepository<PhSubCategory>
    {
        public List<PhSubCategory> GetAll(int ShopID);
        public List<PhSubCategory> GetAll(int ShopID, string Status);
    }
}
