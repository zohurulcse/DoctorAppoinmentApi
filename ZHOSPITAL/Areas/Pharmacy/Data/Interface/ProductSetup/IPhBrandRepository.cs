using System;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
//using ZHOSPITAL.Areas.Pharmacy.ViewModel.API.Product;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup
{
    public interface IPhBrandRepository : IBaseRepository<PhBrand>
    {
        public List<PhBrand> GetAll(int ShopID);
        public List<PhBrand> GetAll(int shopID, string Status);
        //public List<PhBrandViewModel> GetAllBrand();

    }
}
