using System;
using System.Collections.Generic;
using ZAPI.Database.Base;
using ZAPI.Database.Interface;
using ZAPI.Models.Setup;

namespace ZAPI.Database.Repository
{
    public class BazarRepository : BaseRepository<Bazar>, IBazarRepository
    {
        public List<Bazar> GetAll(string ThanaCode)
        {
            List<Bazar> bazars = _db.Bazar.Where(t => t.ThanaCode == ThanaCode).ToList();
            return bazars;
        }
        public List<Bazar> GetAll(string CompanyCode, string Status)
        {
            List<Bazar> bazars = _db.Bazar.Where(c => c.Status == Status).ToList();
            return bazars;
        }
        public List<Bazar> GetAll(string CompanyCode, string Status, string GroupCode)
        {
            List<Bazar> bazars = _db.Bazar.Where(c => c.Status == Status).ToList();
            return bazars;
        }
        public List<Bazar> GetSearch(string SearchValue)
        {
            SearchValue = SearchValue.ToLower();
            List<Bazar> bazars = _db.Bazar.Where(c => c.Code.ToLower().Contains(SearchValue)
                                                                        || c.BazarName.ToLower().Contains(SearchValue)).OrderBy(c => c.Code).ToList();
            return bazars;
        }
    }
}
