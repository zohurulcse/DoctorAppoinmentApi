using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Models.Common;
using ZHOSPITAL.Areas.Pharmacy.Models.CRM;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.DoctorAppoinment
{
    public class DADoctorSetupRepository : BaseRepository<DADoctorSetup>, IDADoctorSetupRepository
    {
        public DADoctorSetupRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<DADoctorSetup> GetAllDoctors()
        {
            List<DADoctorSetup> departments =(from d in _db.DADoctorSetup
                                              join dept in _db.DADepartment on d.DepartmentID equals dept.DepartmentID
                                              join ass in _db.DAAssociateType on d.AssociateTypeID equals ass.AssociateTypeID
                                              select new DADoctorSetup()
                                              {
                                                  DoctorID= d.DoctorID,
                                                  DoctorName= d.DoctorName, 
                                                  DoctorTitle= d.DoctorTitle,
                                                  DepartmentName= dept.DepartmentName,
                                                  AssociateName= ass.AssociateType,  
                                                  ImageByte = d.ImageByte,
                                              }).ToList();
            return departments;
        }

        public async Task<DADoctorSetup> GetDoctorsByID(int doctorID)
        {
            DADoctorSetup departments =await (from d in _db.DADoctorSetup.Where(x=> x.DoctorID == doctorID)
                                               join dept in _db.DADepartment on d.DepartmentID equals dept.DepartmentID
                                               join ass in _db.DAAssociateType on d.AssociateTypeID equals ass.AssociateTypeID
                                               //join ts in _db.DATimeSlotSetup on d.DoctorID equals ts.DoctorID
                                               select new DADoctorSetup()
                                               {
                                                   ID= d.DoctorID.ToString(),
                                                   DoctorID = d.DoctorID,
                                                   DoctorName = d.DoctorName,
                                                   DoctorTitle = d.DoctorTitle,
                                                   DepartmentName = dept.DepartmentName,
                                                   AssociateName = ass.AssociateType,
                                                   DoctorDescription=d.DoctorDescription,
                                                   ImageByte=d.ImageByte,
                                                   DATimeSlotList = _db.DATimeSlotSetup.Where(x=> x.DoctorID == d.DoctorID).ToList(),
                                                   //ScheduleDate=ts.ScheduleDate.ToString("dd-MMM-yyyy"),
                                                   //ScheduleTime= ts.ScheduleTime.ToString("hh:mm tt"),
                                               }).SingleOrDefaultAsync();
            return departments;
        }

        public IList<DADoctorSetup> GetDoctorsByDepartmentID(int departmentID)
        {
            IList<DADoctorSetup> departments = (from d in _db.DADoctorSetup.Where(x => x.DepartmentID == departmentID)
                                               join dept in _db.DADepartment on d.DepartmentID equals dept.DepartmentID
                                               join ass in _db.DAAssociateType on d.AssociateTypeID equals ass.AssociateTypeID
                                               //join ts in _db.DATimeSlotSetup on d.DoctorID equals ts.DoctorID
                                               select new DADoctorSetup()
                                               {
                                                   ID = d.DoctorID.ToString(),
                                                   DoctorID = d.DoctorID,
                                                   DoctorName = d.DoctorName,
                                                   DoctorTitle = d.DoctorTitle,
                                                   DepartmentName = dept.DepartmentName,
                                                   AssociateName = ass.AssociateType,
                                                   DoctorDescription = d.DoctorDescription,
                                                   ImageByte = d.ImageByte,
                                                   DATimeSlotList = _db.DATimeSlotSetup.Where(x => x.DoctorID == d.DoctorID).ToList(),
                                                   //ScheduleDate=ts.ScheduleDate.ToString("dd-MMM-yyyy"),
                                                   //ScheduleTime= ts.ScheduleTime.ToString("hh:mm tt"),
                                               }).ToList();
            return departments;
        }
    }
}
