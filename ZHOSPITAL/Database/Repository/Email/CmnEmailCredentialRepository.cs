using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Database.Interface.Email;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Database.Repository.Email
{
    public class CmnEmailCredentialRepository : BaseRepository<CmnEmailCredential>, IEmailCredential
    {
        public  CmnEmailCredentialRepository(ZHOSPITALDbContext db) : base(db) { }

        public List<CmnEmailCredential> GetCmnEmailCredentials()
        {
            List<CmnEmailCredential> cmnEmailCredentials = _db.CmnEmailCredentials.ToList();
            return cmnEmailCredentials;
        }
    }
}
