using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup
{
    public interface IPhCategoryRepository : IBaseRepository<PhCategory>
    {
        public List<PhCategory> GetAll(int ShopID);
        public List<PhCategory> GetAll(int ShopID, string Status);
       // public List<VSCategory> GetAll(string ShopCode, string Status, string GroupCode);
       // public List<VSCategoryViewModel> GetAllCategory();
    }
}
