using System;
using System.Collections.Generic;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhUnitRepository : BaseRepository<PhUnit>, IPhUnitRepository
    {
        public PhUnitRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<PhUnit> GetAll()
        {
            List<PhUnit> unit = _db.PhUnit.ToList();
            return unit;
        }

        public List<PhUnit> GetAll(int ShopID)
        {
            List<PhUnit> unit = _db.PhUnit.Where(c => c.ShopID == ShopID).ToList();
            return unit;
        }  

        //public List<VSUnitViewModel> GetAllUnit()
        //{
        //    List<VSUnitViewModel> units = (from cat in _db.VSUnit
        //                                   select new VSUnitViewModel()
        //                                   {
        //                                       //Code = cat.Code,
        //                                       Name = cat.Name,
        //                                       //ShopCode = cat.ShopCode,                                              
        //                                       Status = cat.Status,
        //                                   }).ToList();
        //    return units;
        //}
    }
}
