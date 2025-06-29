using System;
using System.Collections.Generic;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Models.Common;
using ZHOSPITAL.Areas.Pharmacy.Models.CRM;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.DoctorAppoinment
{
    public class DADoctorAppoinmentRepository : BaseRepository<DADoctorAppoinment>, IDADoctorAppoinmentRepository
    {
        public DADoctorAppoinmentRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<DADoctorAppoinment> GetAll()
        {
            List<DADoctorAppoinment> departments = _db.DADoctorAppoinment.ToList();
            return departments;
        }      
    }
}
