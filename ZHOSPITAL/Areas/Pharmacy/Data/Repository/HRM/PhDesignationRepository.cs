
using System.Collections.Generic;
using System.Linq;
using ZHOSPITAL.Areas.Pharmacy.Models.HRM;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhDesignationRepository : BaseRepository<PhDesignation>, IPhDesignationRepository
    {
        public PhDesignationRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        //public List<VSDesignation> GetAll(string CompanyCode)
        //{
        //    List<VSDesignation> designations = _db.VSDesignations.Where(c => c.CompanyCode == CompanyCode).ToList();
        //    return designations;
        //}
        //public List<VSDesignation> GetAll(string CompanyCode, string Status)
        //{
        //    List<VSDesignation> designations = _db.VSDesignations.Where(c => c.CompanyCode == CompanyCode && c.Status == Status).ToList();
        //    return designations;
        //}
    }
}
