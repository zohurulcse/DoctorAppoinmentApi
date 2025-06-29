using System;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Models.Authority;

namespace ZHOSPITAL.Database.Interface.Authority
{
    public interface ICmnUserRepository : IBaseRepository<CmnUser>   
    {
        public CmnUser LoginEmail(string email, string password);
        public CmnUser LoginMobile(string mobile, string password);
        public CmnUser GetByEmail(string email);
        public CmnUser GetByMobile(string mobile);
    }
}
