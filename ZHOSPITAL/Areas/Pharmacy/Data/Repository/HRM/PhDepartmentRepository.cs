using System.Collections.Generic;
using System.Linq;
using ZHOSPITAL.Areas.Pharmacy.Models.HRM;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhDepartmentRepository : BaseRepository<PhDepartment>, IPhDepartmentRepository
    {
        public PhDepartmentRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        //public List<VSDepartment> GetAll(string CompanyCode)
        //{
        //    List<VSDepartment> departments = _db.VSDepartments.Where(c => c.CompanyCode == CompanyCode).ToList();
        //    return departments;
        //}
        //public List<VSDepartment> GetAll(string CompanyCode, string Status)
        //{
        //    List<VSDepartment> departments = _db.Departments.Where(c => c.CompanyCode == CompanyCode && c.Status == Status).ToList();
        //    return departments;
        //}
    }
}
