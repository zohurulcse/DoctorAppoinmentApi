using System;
using System.Collections.Generic;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Models.Common;
using ZHOSPITAL.Areas.Pharmacy.Models.CRM;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.DoctorAppoinment
{
    public class DATimeSlotSetupRepository : BaseRepository<DATimeSlotSetup>, IDATimeSlotSetupRepository
    {
        public DATimeSlotSetupRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<DATimeSlotSetup> GetAll()
        {
            List<DATimeSlotSetup> departments = _db.DATimeSlotSetup.ToList();
            return departments;
        }      
    }
}
