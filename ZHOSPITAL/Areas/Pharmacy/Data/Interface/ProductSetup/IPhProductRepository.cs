using System;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup
{
    public interface IPhProductRepository : IBaseRepository<PhProduct>
    {
        public List<PhProduct> GetAllProductsByShopCode(int shopID);
        public List<PhProduct> GetAllECommerce();
        dynamic GetProductStock(int shopID, int productID);
        Task<string> UploadImages(IFormFile? files, string? productID, string? shopID);
        Task<List<PhProduct>> GetAllProudctList(int shopID, string dropdownType);

    }
}
