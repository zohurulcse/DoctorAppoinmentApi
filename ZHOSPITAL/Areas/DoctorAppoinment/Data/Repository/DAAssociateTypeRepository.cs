using System;
using System.Collections.Generic;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Models.Common;
using ZHOSPITAL.Areas.Pharmacy.Models.CRM;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.DoctorAppoinment
{
    public class DAAssociateTypeRepository : BaseRepository<DAAssociateType>, IDAAssociateTypeRepository
    {
        public DAAssociateTypeRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<DAAssociateType> GetAll()
        {
            List<DAAssociateType> departments = _db.DAAssociateType.ToList();
            return departments;
        }      
    }
}
