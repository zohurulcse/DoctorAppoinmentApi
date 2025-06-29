using ZHOSPITAL.Areas.Pharmacy.Models;
using ZHOSPITAL.Areas.Pharmacy.Models.Inventory;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductOrder
{
    public interface IPhProductOrderDetailsRepository : IBaseRepository<PhProductOrderDetail>
    {
        //public List<VSProductOrderVM> GetOrderDetailsWithCustomer(string CustomerCode, string Status);
        //public List<VSProductOrderVM> GetOrderDetailsWithShop(string ShopCode, string Status);
        //public List<VSProductOrderVM> GetProductsByCustomerCode(string Code, string CustomerCode);
        //public List<VSProductOrderVM> GetOrderDetailsWithOperator(string OrderStatus);
        //public List<VSProductOrderVM> GetProductsByOrderCode(string OrderCode);
        //public List<VSProductOrderDetail> GetProductsByShopCode(string HeadCode, string ShopCode);
        //public List<VSPurchaseOrderDetails> GetByHeadDetailsCode(string HeadCode, string DetailsCode);
        //public List<VSProductOrderVM> GetChargeCompany(string FromDate, string ToDate);
        //public List<VSProductOrderViewModel> GetApiProductsByShopCode();//string ShopCode;
    }
}
