using System;
using System.Collections.Generic;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Models.Common;
using ZHOSPITAL.Areas.Pharmacy.Models.CRM;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.DoctorAppoinment
{
    public class DADepartmentRepository : BaseRepository<DADepartment>, IDADepartmentRepository
    {
        public DADepartmentRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<DADepartment> GetAll()
        {
            List<DADepartment> departments = _db.DADepartment.ToList();
            return departments;
        }      
    }
}
