using System;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Database.Interface.Authority;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Database.Repository.Authority
{
    public class LicenseRepository : BaseRepository<License>, ILicenseRepository
    {
        public LicenseRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<License> GetSecurityCode(int shopID)
        {
            List<License> license = _db.License.Where(c => c.ShopID == shopID).ToList();
            return license;
        }
    }
}
