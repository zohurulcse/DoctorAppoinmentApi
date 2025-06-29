using System;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup
{
    public interface IPhStyleRepository : IBaseRepository<PhStyle>
    {
        public List<PhStyle> GetAll(int ShopID);
        //public List<VSStyle> GetAll(string CompanyCode, string Status);
        //public List<VSStyle> GetSearch(string CompanyCode, string SearchValue);
        //public List<VSStyleViewModel> GetAllStyle();
    }
}
