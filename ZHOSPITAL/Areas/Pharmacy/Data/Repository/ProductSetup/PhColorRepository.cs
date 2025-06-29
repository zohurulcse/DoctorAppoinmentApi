using System;
using System.Collections.Generic;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhColorRepository : BaseRepository<PhColor>, IPhColorRepository
    {
        public PhColorRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        //public List<VSColor> GetAll(string Status)
        //{
        //    List<VSColor> color = _db.VSColor.Where(c => c.Status == Status).ToList();
        //    return color;
        //}
        //public List<VSColor> GetAll(string CompanyCode, string Status)
        //{
        //    List<VSColor> color = _db.VSColor.Where(c => c.CompanyCode == CompanyCode && c.Status == Status).ToList();
        //    return color;
        //}
        //public List<VSColor> GetSearch(string CompanyCode, string SearchValue)
        //{
        //    SearchValue = SearchValue.ToLower();
        //    List<VSColor> color = _db.Color.Where(c => c.CompanyCode == CompanyCode && (c.Code.ToLower().Contains(SearchValue))).OrderBy(c => c.Code).ToList();
        //    return color;
        //}

        //public List<VSColorViewModel> GetAllColor()
        //{
        //    List<VSColorViewModel> colors = (from cat in _db.Color
        //                                   select new VSColorViewModel()
        //                                 {
        //                                     Code = cat.Code,
        //                                     Name = cat.ColorName,                                                                                         
        //                                     Status = cat.Status,
        //                                 }).ToList();
        //    return colors;
        //}
    }
}
