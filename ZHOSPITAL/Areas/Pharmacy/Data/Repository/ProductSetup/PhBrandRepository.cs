using System;
using System.Collections.Generic;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhBrandRepository : BaseRepository<PhBrand>, IPhBrandRepository
    {
        public PhBrandRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<PhBrand> GetAll()
        {
            List<PhBrand> brand = _db.PhBrand.ToList();
            return brand;
        }
        public List<PhBrand> GetAll(int shopID)
        {
            List<PhBrand> brand = _db.PhBrand.Where(c => c.ShopID == shopID).ToList();
            return brand;
        }
        public List<PhBrand> GetAll(int shopID, string Status)
        {
            List<PhBrand> brands = _db.PhBrand.Where(c => c.ShopID == shopID && c.Status == Status).ToList();
            return brands;
        }

        //public List<VSBrandViewModel> GetAllBrand()
        //{
        //    List<VSBrandViewModel> brands = (from cat in _db.VSBrand
        //                                     select new VSBrandViewModel()
        //                                         {
        //                                             ID = cat.ID,
        //                                             Name = cat.Name,
        //                                             ShopID = cat.ShopID,                                                                                                       
        //                                             Status = cat.Status,
        //                                             Photo = cat.Photo
        //                                         }).ToList();
        //    return brands;
        //}
    }
}
