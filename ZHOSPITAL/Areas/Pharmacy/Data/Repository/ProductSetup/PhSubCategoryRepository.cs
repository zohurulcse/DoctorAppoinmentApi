using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhSubCategoryRepository : BaseRepository<PhSubCategory>, IPhSubCategoryRepository
    {
        public PhSubCategoryRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<PhSubCategory> GetAll()
        {
            List<PhSubCategory> categorys = _db.PhSubCategorys.ToList();
            return categorys;
        }
        public List<PhSubCategory> GetAll(int shopID)
        {
            List<PhSubCategory> categorys = _db.PhSubCategorys.Where(c => c.ShopID == shopID).ToList();
            return categorys;
        }
        public List<PhSubCategory> GetAll(int shopID, string Status)
        {
            List<PhSubCategory> categorys = _db.PhSubCategorys.Where(c => c.ShopID == shopID && c.Status == Status).ToList();
            return categorys;
        }      
        //public List<VSCategoryViewModel> GetAllCategory()
        //{
        //    List<VSCategoryViewModel> categorys =(from cat in _db.VSCategorys
        //                                          select new VSCategoryViewModel()
        //                               {
        //                                   Code=cat.Code,
        //                                   Name=cat.Name,
        //                                   ShopCode=cat.ShopCode,                                                                            
        //                                   Status=cat.Status,
        //                                   Photo=cat.Photo
        //                               }).ToList();
        //    return categorys;
        //}

    }
}
