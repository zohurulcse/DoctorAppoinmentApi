using System;
using System.Collections.Generic;
using ZAPI.Database.Base;
using ZAPI.Database.Interface;
using ZAPI.Models.Setup;

namespace ZAPI.Database.Repository
{
    public class DivisionRepository : BaseRepository<Division>, IDivisionRepository
    {
        public List<Division> GetAll(string CompanyCode)
        {
            List<Division> divisions = _db.Division.ToList();
            return divisions;
        }
        public List<Division> GetAll(string CompanyCode, string Status)
        {
            List<Division> divisions = _db.Division.Where(c => c.Status == Status).ToList();
            return divisions;
        }

        public List<Division> GetSearch(string SearchValue)
        {
            SearchValue = SearchValue.ToLower();
            List<Division> divisions = _db.Division.Where(c => c.Code.ToLower().Contains(SearchValue)
                                                                        || c.DivisionName.ToLower().Contains(SearchValue)).OrderBy(c => c.Code).ToList();
            return divisions;
        }
    }
}
