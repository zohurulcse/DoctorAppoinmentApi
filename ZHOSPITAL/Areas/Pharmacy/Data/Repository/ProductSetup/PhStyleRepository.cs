using System;
using System.Collections.Generic;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhStyleRepository : BaseRepository<PhStyle>, IPhStyleRepository
    {
        public PhStyleRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<PhStyle> GetAll(int ShopID)
        {
            List<PhStyle> style = _db.PhStyle.Where(c => c.ShopID == ShopID).ToList();
            return style;
        }     

        //public List<VSStyleViewModel> GetAllStyle()
        //{
        //    List<VSStyleViewModel> brands = (from cat in _db.VSStyle
        //                                   select new VSStyleViewModel()
        //                                   {
        //                                       //Code = cat.Code,
        //                                       Name = cat.Name,
        //                                       //ShopCode = cat.ShopCode,                                           
        //                                       Status = cat.Status,                                              
        //                                   }).ToList();
        //    return brands;
        //}
    }
}
