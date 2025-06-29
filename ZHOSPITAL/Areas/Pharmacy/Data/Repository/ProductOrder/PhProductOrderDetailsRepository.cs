using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductOrder;
using ZHOSPITAL.Areas.Pharmacy.Models;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Repository.ProductOrder
{
    public class PhProductOrderDetailsRepository : BaseRepository<PhProductOrderDetail>, IPhProductOrderDetailsRepository

    {
        public PhProductOrderDetailsRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        //public List<VSProductOrderDetail> GetAll()
        //{
        //    List<VSProductOrderDetail> productOrderDetails = new List<VSProductOrderDetail>();
        //    try
        //    {
        //        productOrderDetails = _db.VSProductOrderDetail.ToList();
        //    }
        //    catch (Exception ex) { }
        //    return productOrderDetails;
        //}

        //public List<VSProductOrderVM> GetOrderDetailsWithCustomer(string CustomerCode,string Status)
        //{
        //    List<VSProductOrderVM> productOrder = (from oh in _db.VSProductOrder
        //                                      //join od in _db.ProductOrderDetail on oh.Code equals od.HeadCode
        //                                      //join sh in _db.ShopSetup on od.ShopCode equals sh.Code
        //                                      //join p in _db.Products on od.ProductCode equals p.Code
        //                                      where oh.CustomerCode==CustomerCode //&& oh.OrderStatus == Status
        //                                         select new VSProductOrderVM()
        //                                      {
        //                                          Code = oh.Code,
        //                                          //ProductCode = od.ProductCode,
        //                                          //ProductName =od.ProductName,
        //                                          //Photo = p.Photo,
        //                                          OrderDate = oh.OrderDate,                                                 
        //                                          //Quantity = od.Quantity,
        //                                          //Price=od.Price,
        //                                          //Amount=od.Amount,
        //                                          //ShopCode=od.ShopCode,
        //                                          //ShopName=sh.ShopName,
        //                                          OrderStatus=oh.OrderStatus,
        //                                          Remarks = oh.Remarks
        //                                         }).OrderByDescending(x=> x.Code).ToList();           
        //    return productOrder;

        //}

        //public List<VSProductOrderVM> GetOrderDetailsWithShop(string ShopCode,string Status)
        //{
        //    decimal smartbazarCharge = Convert.ToDecimal(0.50);
        //    List<VSProductOrderVM> productOrder = (from oh in _db.VSProductOrder
        //                                           join od in _db.VSProductOrderDetail on oh.Code equals od.HeadCode
        //                                         //join sh in _db.ShopSetup on od.ShopCode equals sh.Code
        //                                         //join p in _db.Products on od.ProductCode equals p.Code
        //                                         join c in _db.VSCustomers on oh.CustomerCode equals c.Code
        //                                         where od.ShopCode == ShopCode && oh.OrderStatus == Status
        //                                         //group oh by oh.Code into g
        //                                         select new VSProductOrderVM()
        //                                         {
        //                                             Code = oh.Code,
        //                                             //ProductCode = od.ProductCode,
        //                                             //ProductName = od.ProductName,
        //                                             //Photo = p.Photo,
        //                                             OrderDate = oh.OrderDate,
        //                                             //Quantity = od.Quantity,
        //                                             //Price = od.Price,
        //                                             //Amount = od.Amount,
        //                                             //ShopCode = od.ShopCode,
        //                                             //ShopName = sh.ShopName,
        //                                             OrderStatus = oh.OrderStatus,
        //                                             CustomerCode=oh.CustomerCode,
        //                                             //CustomerName=oh.VSCustomer.Name,
        //                                             Remarks = oh.Remarks,
        //                                             //ControllerChargeAmount = (String.Format("{0:0.00}", od.Amount * 2 / 100)),
        //                                             //SmartbazarChargeAmount = (String.Format("{0:0.00}", od.Amount * smartbazarCharge / 100)),
        //                                             //CustomerName=c.Name
        //                                         }).ToList();
        //    return productOrder;

        //}

        //public List<VSProductOrderVM> GetProductsByCustomerCode(string Code,string CustomerCode)
        //{
        //    decimal smartbazarCharge = Convert.ToDecimal(0.50);
        //    List<VSProductOrderVM> productOrder = (from oh in _db.VSProductOrder
        //                                           join od in _db.VSProductOrderDetail on oh.Code equals od.HeadCode
        //                                         join sh in _db.VSShopSetup on od.ShopCode equals sh.Code
        //                                         join p in _db.VSProducts on od.ProductCode equals p.Code
        //                                         join c in _db.VSCustomers on oh.CustomerCode equals c.Code
        //                                         where oh.CustomerCode == CustomerCode && oh.Code == Code
        //                                         select new VSProductOrderVM()
        //                                         {
        //                                             Code = oh.Code,
        //                                             ProductCode = od.ProductCode,
        //                                             ProductName = od.ProductName,
        //                                             Photo = p.Photo,
        //                                             OrderDate = oh.OrderDate,
        //                                             Quantity = od.Quantity,
        //                                             Price = od.Price,
        //                                             Amount = od.Amount,
        //                                             ShopCode = od.ShopCode,
        //                                             ShopName = sh.ShopName,
        //                                             OrderStatus = oh.OrderStatus,
        //                                             CustomerCode = oh.CustomerCode,
        //                                            // CustomerName = oh.VSCustomer.Name,
        //                                             Remarks = oh.Remarks,
        //                                             //ControllerChargeAmount = (String.Format("{0:0.00}", od.Amount * 2 / 100)),
        //                                             //SmartbazarChargeAmount = (String.Format("{0:0.00}", od.Amount * smartbazarCharge / 100)),
        //                                             //CustomerName=c.Name
        //                                         }).ToList();
        //    return productOrder;

        //}

        //public List<VSProductOrderVM> GetOrderDetailsWithOperator(string OrderStatus)
        //{
        //    decimal smartbazarCharge = Convert.ToDecimal(0.50);
        //    List<VSProductOrderVM> productOrder = (from oh in _db.VSProductOrder
        //                                         //join od in _db.ProductOrderDetail on oh.Code equals od.HeadCode
        //                                         //join sh in _db.ShopSetup on od.ShopCode equals sh.Code
        //                                         //join p in _db.Products on od.ProductCode equals p.Code
        //                                         join c in _db.VSCustomers on oh.CustomerCode equals c.Code
        //                                         where oh.OrderStatus == OrderStatus
        //                                         select new VSProductOrderVM()
        //                                         {
        //                                             Code = oh.Code,
        //                                             //ProductCode = od.ProductCode,
        //                                             //ProductName = od.ProductName,
        //                                             //Photo = p.Photo,
        //                                             OrderDate = oh.OrderDate,
        //                                             //Quantity = od.Quantity,
        //                                             //Price = od.Price,
        //                                             //Amount = od.Amount,
        //                                             //ShopCode = od.ShopCode,
        //                                             //ShopName = sh.ShopName,
        //                                             //OrderStatus = od.Status,
        //                                             CustomerCode=oh.CustomerCode,
        //                                             CustomerName=c.Name,
        //                                             CustomerMobile=c.Contact,
        //                                             CustomerAddress=c.Address,
        //                                             CustomerFathers=c.FatherName,     
        //                                             ParaMoholla=c.ParaMoholla,      
        //                                             Remarks=oh.Remarks,                                          
        //                                             CustomerPhoto="",
        //                                             //ControllerChargeAmount = (String.Format("{0:0.00}", oh.TotalAmount * 2 / 100)),
        //                                             //SmartbazarChargeAmount = (String.Format("{0:0.00}", oh.TotalAmount * smartbazarCharge / 100)),                                                     
        //                                         }).OrderByDescending(x => x.Code).ToList();
        //    return productOrder;

        //}

        ////public List<PurchaseOrderDetails> GetAll(string searchValue)
        ////{
        ////    List<PurchaseOrderDetails> purchaseDetails = _db.PurchaseOrderDetails.Where(c => c.Barcode == searchValue).ToList();
        ////    return purchaseDetails;
        ////}

        //public List<VSProductOrderDetail> GetByHeadCode(string HeadCode)
        //{
        //    List<VSProductOrderDetail> productOrderDetail = _db.VSProductOrderDetail.Where(c => c.HeadCode == HeadCode).ToList();
        //    return productOrderDetail;
        //}

        //public List<VSProductOrderVM> GetProductsByOrderCode(string OrderCode)
        //{
        //    decimal smartbazarCharge = Convert.ToDecimal(0.50);
        //    List<VSProductOrderVM> productOrder = (from od in _db.VSProductOrderDetail
        //                                           where od.HeadCode == OrderCode
        //                                         join oh in _db.VSProductOrder on od.HeadCode equals oh.Code
        //                                         join c in _db.VSCustomers on oh.CustomerCode equals c.Code
        //                                         join sh in _db.VSShopSetup on od.ShopCode equals sh.Code
        //                                         join p in _db.VSProducts on od.ProductCode equals p.Code

        //                                         select new VSProductOrderVM()
        //                                         {
        //                                             Code = od.HeadCode,
        //                                             ProductCode = od.ProductCode,
        //                                             ProductName = od.ProductName,
        //                                             Photo = p.Photo,
        //                                             OrderDate = oh.OrderDate,
        //                                             CustomerCode = oh.CustomerCode,
        //                                             CustomerName = c.Name,
        //                                             CustomerFathers=c.FatherName,
        //                                             ParaMoholla=c.ParaMoholla,
        //                                             Village=c.Village,
        //                                             CustomerMobile=c.Contact,
        //                                             CustomerAddress = c.Address,
        //                                             Remarks = oh.Remarks,
        //                                             CustomerPhoto = "",
        //                                             Quantity = od.Quantity,
        //                                             Price = od.Price,
        //                                             Amount = od.Amount,
        //                                             ShopCode = od.ShopCode,
        //                                             ShopName = sh.ShopName,
        //                                             TotalAmount=oh.TotalAmount,
        //                                             ControllerChargeAmount = od.Amount * 2 / 100,
        //                                             SmartbazarChargeAmount = od.Amount * smartbazarCharge / 100
        //                                             //OrderStatus = od.Status,                                                   
        //                                         }).OrderByDescending(x => x.Code).ToList();
        //    return productOrder;

        //}

        //public List<VSProductOrderDetail> GetProductsByShopCode(string HeadCode,string ShopCode)
        //{
        //    List<VSProductOrderDetail> productOrderDetail = _db.VSProductOrderDetail.Where(c => c.HeadCode == HeadCode && c.ShopCode==ShopCode).ToList();
        //    return productOrderDetail;
        //}

        //public List<VSPurchaseOrderDetails> GetByHeadDetailsCode(string HeadCode, string DetailsCode)
        //{
        //    List<VSPurchaseOrderDetails> purchaseDetails = _db.VSPurchaseOrderDetails.Where(c => c.HeadCode == HeadCode && c.Code == DetailsCode).ToList();
        //    return purchaseDetails;
        //}

        //public List<VSProductOrderVM> GetChargeCompany(string FromDate, string ToDate)
        //{
        //    decimal smartbazarCharge = Convert.ToDecimal(0.50);
        //    DateTime FromDate1 = Convert.ToDateTime(FromDate);
        //    DateTime ToDate1 = Convert.ToDateTime(ToDate);
        //    List<VSProductOrderVM> productOrder = (from oh in _db.VSProductOrder
        //                                           where oh.OrderDate >= FromDate1 && oh.OrderDate <= ToDate1
        //                                         join od in _db.VSProductOrderDetail on oh.Code equals od.HeadCode
        //                                         join c in _db.VSCustomers on oh.CustomerCode equals c.Code
        //                                         join sh in _db.VSShopSetup on od.ShopCode equals sh.Code
        //                                         join p in _db.VSProducts on od.ProductCode equals p.Code                                                 
        //                                         select new VSProductOrderVM()
        //                                         {
        //                                             Code = od.HeadCode,
        //                                             ProductCode = od.ProductCode,
        //                                             ProductName = od.ProductName,
        //                                             Photo = p.Photo,
        //                                             OrderDate = oh.OrderDate,
        //                                             CustomerCode = oh.CustomerCode,
        //                                             CustomerName = c.Name,
        //                                             CustomerFathers = c.FatherName,
        //                                             ParaMoholla = c.ParaMoholla,
        //                                             Village = c.Village,
        //                                             CustomerMobile = c.Contact,
        //                                             CustomerAddress = c.Address,
        //                                             Remarks = oh.Remarks,
        //                                             CustomerPhoto = "",
        //                                             Quantity = od.Quantity,
        //                                             Price = od.Price,
        //                                             Amount = od.Amount,
        //                                             ShopCode = od.ShopCode,
        //                                             ShopName = sh.ShopName,
        //                                             TotalAmount = oh.TotalAmount,
        //                                             ControllerChargeAmount = Decimal.Round(od.Amount * 2 / 100),
        //                                             SmartbazarChargeAmount = Decimal.Round(od.Amount * smartbazarCharge / 100, 4)
        //                                         }).OrderByDescending(x => x.Code).ToList();
        //    return productOrder;

        //}

        //public List<VSProductOrderViewModel> GetApiProductsByShopCode()//string ShopCode
        //{
        //    decimal smartbazarCharge = Convert.ToDecimal(0.50);
        //    List<VSProductOrderViewModel> productOrder = (from oh in _db.VSProductOrder
        //                                                  join od in _db.VSProductOrderDetail on oh.Code equals od.HeadCode                                   
        //                                         join c in _db.VSCustomers on oh.CustomerCode equals c.Code
        //                                         //where od.ShopCode == ShopCode                                                 
        //                                         select new VSProductOrderViewModel()
        //                                         {
        //                                             OrderCode = oh.Code,
        //                                             ProductCode = od.ProductCode,
        //                                             ProductName = od.ProductName,
        //                                             //Photo = p.Photo,
        //                                             OrderDate = oh.OrderDate,
        //                                             Quantity = (int)od.Quantity,
        //                                             UnitPrice = od.Price,
        //                                             Amount = od.Amount,
        //                                             //ShopCode = od.ShopCode,
        //                                             //ShopName = sh.ShopName,
        //                                             OrderStatus = oh.OrderStatus,
        //                                             //CustomerCode = oh.CustomerCode,
        //                                             //CustomerName = oh.Customer.Name,
        //                                             //Remarks = oh.Remarks,

        //                                         }).ToList();
        //    return productOrder;

        //}

    }
}
