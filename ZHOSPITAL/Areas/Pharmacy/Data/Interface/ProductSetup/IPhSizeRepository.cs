using System;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup
{
    public interface IPhSizeRepository : IBaseRepository<PhSize>
    {
        public List<PhSize> GetAll(int ShopID);
        //public List<VSSize> GetAll(string CompanyCode, string Status);
        //public List<VSSize> GetSearch(string CompanyCode, string SearchValue);
        //public List<VSSizeViewModel> GetAllSize();
    }
}
