using ZAPI.Database.Base;
using ZAPI.Database.Interface;
using ZAPI.Models.Setup;

namespace ZAPI.Database.Repository
{
    public class DistrictRepository : BaseRepository<District>, IDistrictRepository
    {
        public List<District> GetAll(string DivisionCode)
        {
            List<District> districts = _db.District.Where(d => d.DivisionCode == DivisionCode).ToList();
            return districts;
        }
        public List<District> GetAll(string CompanyCode, string Status)
        {
            List<District> districts = _db.District.Where(c => c.Status == Status).ToList();
            return districts;
        }
        public List<District> GetAll(string CompanyCode, string Status, string GroupCode)
        {
            List<District> districts = _db.District.Where(c => c.Status == Status).ToList();
            return districts;
        }
        public List<District> GetSearch(string SearchValue)
        {
            SearchValue = SearchValue.ToLower();
            List<District> districts = _db.District.Where(c => c.Code.ToLower().Contains(SearchValue)
                                                                        || c.DistrictName.ToLower().Contains(SearchValue)).OrderBy(c => c.Code).ToList();
            return districts;
        }
    }
}
