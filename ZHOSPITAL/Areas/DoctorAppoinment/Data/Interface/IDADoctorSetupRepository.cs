using System;
using ZHOSPITAL.Areas.Pharmacy.Models.Common;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.DoctorAppoinment
{
    public interface IDADoctorSetupRepository : IBaseRepository<DADoctorSetup>
    {
        List<DADoctorSetup> GetAllDoctors();
        Task<DADoctorSetup> GetDoctorsByID(int doctorID);
        IList<DADoctorSetup> GetDoctorsByDepartmentID(int departmentID);
    }
}
