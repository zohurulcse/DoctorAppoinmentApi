using System;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Database.Interface.Authority
{
    public interface ILicenseRepository : IBaseRepository<License>
    {
        public List<License> GetSecurityCode(int shopID);
    }
}
