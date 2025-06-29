using System;
using System.Collections.Generic;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhSizeRepository : BaseRepository<PhSize>, IPhSizeRepository
    {
        public PhSizeRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<PhSize> GetAll(int ShopID)
        {
            List<PhSize> size = _db.PhSize.Where(c => c.ShopID == ShopID).ToList();
            return size;
        }
        //public List<VSSize> GetAll(string ShopCode, string Status)
        //{
        //    List<VSSize> size = _db.VSSize.Where(c => c.Code == ShopCode && c.Status == Status).ToList();
        //    return size;
        //}
        //public List<VSSize> GetSearch(string ShopCode, string SearchValue)
        //{
        //    SearchValue = SearchValue.ToLower();
        //    List<VSSize> sizes = _db.VSSize.Where(c => c.Code == ShopCode && (c.Code.ToLower().Contains(SearchValue)
        //                                                                || c.Name.ToLower().Contains(SearchValue))).OrderBy(c => c.Code).ToList();
        //    return sizes;
        //}

        //public List<VSSizeViewModel> GetAllSize()
        //{
        //    List<VSSizeViewModel> sizes = (from x in _db.VSSize
        //                                  select new VSSizeViewModel()
        //                                   {
        //                                       Code = x.Code,
        //                                       Name = x.Name,                                              
        //                                       Status = x.Status,
        //                                   }).ToList();
        //    return sizes;
        //}
    }
}
