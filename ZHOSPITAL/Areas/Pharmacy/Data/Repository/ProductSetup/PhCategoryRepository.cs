using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhCategoryRepository : BaseRepository<PhCategory>, IPhCategoryRepository
    {
        public PhCategoryRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<PhCategory> GetAll()
        {
            List<PhCategory> categorys = _db.PhCategorys.ToList();
            return categorys;
        }
        public List<PhCategory> GetAll(int ShopID)
        {
            List<PhCategory> categorys = _db.PhCategorys.Where(c => c.ShopID == ShopID).ToList();
            return categorys;
        }
        public List<PhCategory> GetAll(int ShopID, string Status)
        {
            List<PhCategory> categorys = _db.PhCategorys.Where(c => c.ShopID == ShopID && c.Status == Status).ToList();
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
