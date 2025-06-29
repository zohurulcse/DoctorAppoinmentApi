using System;
using System.Collections.Generic;
using ZAPI.Database.Base;
using ZAPI.Database.Interface;
using ZAPI.Models.Setup;

namespace ZAPI.Database.Repository
{
    public class ThanaRepository : BaseRepository<Thana>, IThanaRepository
    {
        public List<Thana> GetAll(string DistrictCode)
        {
            List<Thana> thanas = _db.Thana.Where(d => d.DistrictCode == DistrictCode).ToList();
            return thanas;
        }
        public List<Thana> GetAll(string CompanyCode, string Status)
        {
            List<Thana> thanas = _db.Thana.Where(c => c.Status == Status).ToList();
            return thanas;
        }
        public List<Thana> GetAll(string CompanyCode, string Status, string GroupCode)
        {
            List<Thana> thanas = _db.Thana.Where(c => c.Status == Status).ToList();
            return thanas;
        }
        public List<Thana> GetSearch(string SearchValue)
        {
            SearchValue = SearchValue.ToLower();
            List<Thana> thanas = _db.Thana.Where(c => c.Code.ToLower().Contains(SearchValue)
                                                                        || c.ThanaName.ToLower().Contains(SearchValue)).OrderBy(c => c.Code).ToList();
            return thanas;
        }
    }
}
