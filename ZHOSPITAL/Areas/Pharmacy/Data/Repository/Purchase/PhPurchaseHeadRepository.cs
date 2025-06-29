using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ZHOSPITAL.Utility;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Purchase;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Database.Utility;
using static ZHOSPITAL.Utility.StoreProcedure;
using ZHOSPITAL.Areas.Pharmacy.ViewModel;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Repository.Purchase
{
    public class PhPurchaseHeadRepository : BaseRepository<PhPurchaseHead>, IPhPurchaseHeadRepository
    {
        private readonly IDBAccess _dbAccess;
        public PhPurchaseHeadRepository(ZHOSPITALDbContext db, IDBAccess dbAccess) : base(db)
        {
            _dbAccess = dbAccess;
        }

        public List<PhPurchaseHead> GetAll()//int ShopID
        {
            List<PhPurchaseHead> purchaseHeads = (from ph in _db.PhPurchaseHeads
                                                  join sup in _db.PhSuppliers on ph.SupplierID equals sup.ID
                                                //where ph.ShopID == ShopID
                                                select new PhPurchaseHead()
                                                {
                                                    SupplierName = sup.Name,
                                                    CustomCode = ph.CustomCode,
                                                    InnvoiceNumber=ph.InnvoiceNumber,
                                                    Remarks = ph.Remarks,
                                                    Status = ph.Status,
                                                    NetAmount = ph.NetAmount,
                                                    TotalQuantity = ph.TotalQuantity,
                                                    //purchaseDetails = ph.purchaseDetails
                                                    PhPurchaseDetails = ph.PhPurchaseDetails.Select(p => new PhPurchaseDetails

                                                    {
                                                        ID = p.ID,
                                                        ProductName = _db.PhProducts.Where(x => x.ID == p.ProductID).Select(y => y.Name).FirstOrDefault(),
                                                        Quantity = p.Quantity,
                                                        CostPrice = p.CostPrice,
                                                        SalesPrice = p.SalesPrice,
                                                        TotalAmount = p.TotalAmount
                                                    }).ToList()

                                                }).ToList();
            if (purchaseHeads.Count != 0)
            {
                return purchaseHeads;
            }
            else
            {
                PhPurchaseHead purchaseVM = new PhPurchaseHead();
                purchaseHeads.Add(purchaseVM);
                return purchaseHeads;
            }

        }

        public async Task<List<PhPurchaseHead>> GetAllPurchaseCustomCode(int shopID, string type)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<PhPurchaseHead>)await _con.QueryAsync<PhPurchaseHead>(
                sql: Convert.ToString(StoreProcedure.Name.SP_VSDropDownProvider),
                    param: new
                    {
                        Action = type,
                        ShopID = shopID
                    },
                commandType: CommandType.StoredProcedure);
            return objList ?? new List<PhPurchaseHead>();
        }

        public List<PhPurchaseHead> GetDataByShop(int ShopID, string approvedStatus)
        {
            List<PhPurchaseHead> purchaseHeads = (from ph in _db.PhPurchaseHeads
                                                  join sup in _db.PhSuppliers on ph.SupplierID equals sup.ID
                                                  where ph.ShopID == ShopID && ph.ApproveStatus == approvedStatus
                                                  select new PhPurchaseHead()
                                                  {
                                                      ID = ph.ID,
                                                      SupplierName = sup.Name,
                                                      CustomCode = ph.CustomCode,
                                                      InnvoiceNumber = ph.InnvoiceNumber,
                                                      Remarks = ph.Remarks,
                                                      Status = ph.Status,
                                                      ApproveStatus = ph.ApproveStatus,
                                                      NetAmount = ph.NetAmount,
                                                      TotalQuantity = ph.TotalQuantity,
                                                      PurchaseDate = Convert.ToDateTime(ph.PurchaseDate.ToShortDateString()),                                                     
                                                      PhPurchaseDetails = ph.PhPurchaseDetails.Select(p => new PhPurchaseDetails

                                                      {
                                                          ID = p.ID,
                                                          ProductName = _db.PhProducts.Where(x => x.ID == p.ProductID).Select(y => y.Name).FirstOrDefault(),
                                                          Quantity = p.Quantity,
                                                          CostPrice = p.CostPrice,
                                                          SalesPrice = p.SalesPrice,
                                                          TotalAmount = p.TotalAmount
                                                      }).ToList()

                                                  }).ToList();
            if (purchaseHeads.Count != 0)
            {
                return purchaseHeads;
            }
            else
            {
                PhPurchaseHead purchaseVM = new PhPurchaseHead();
                purchaseHeads.Add(purchaseVM);
                return purchaseHeads;
            }

        }

        public List<PhPurchaseVM> GetAllUnApprove(int ShopCode)
        {
            List<PhPurchaseVM> purchaseHeads = (from ph in _db.PhPurchaseHeads
                                                where ph.ShopID == ShopCode && ph.Status == "Pending"
                                                select new PhPurchaseVM()
                                                {
                                                    TotalAmount = ph.NetAmount,
                                                    TotalQuantity = ph.TotalQuantity
                                                }).ToList();

            if (purchaseHeads.Count != 0)
            {
                return purchaseHeads;
            }
            else
            {
                PhPurchaseVM purchaseVM = new PhPurchaseVM();
                purchaseHeads.Add(purchaseVM);
                return purchaseHeads;
            }

        }

        public List<PhPurchaseVM> GetAll(string BranchCode)
        {          
            List<PhPurchaseVM> purchaseHeads = (from ph in _db.PhPurchaseHeads
                                                    //where ph.BranchCode == BranchCode 
                                                    //join pd in _db.PurchaseDetails on ph.Code equals pd.HeadCode
                                                    //join p in _db.Products on pd.ProductCode equals p.Code
                                                select new PhPurchaseVM()
                                                {
                                                    //Code = ph.Code,
                                                    ////ProductCode = p.Code,
                                                    ////ProductName = p.Name,
                                                    ////Photo = p.Photo,
                                                    //Date = ph.Date,
                                                    TotalAmount = ph.NetAmount,
                                                    TotalQuantity = ph.TotalQuantity
                                                    //SalePrice = pd.SalesPrice
                                                }).ToList();

            if (purchaseHeads.Count != 0)
            {
                return purchaseHeads;
            }
            else
            {
                PhPurchaseVM purchaseVM = new PhPurchaseVM();
                purchaseHeads.Add(purchaseVM);
                return purchaseHeads;
            }

        }

        public List<PhPurchaseVM> GetProductDetails(int ProductID, int ShopID)
        {
            List<PhPurchaseVM> purchaseHeads = (from ph in _db.PhPurchaseHeads
                                                join pd in _db.PhPurchaseDetails on ph.ID equals pd.PhPurchaseHead.ID
                                                join p in _db.PhProducts on pd.ProductID equals p.ID
                                                where pd.ProductID == ProductID && ph.ShopID == ShopID && pd.Quantity > 0 && pd.SalesPrice > 0 && pd.CostPrice > 0
                                                select new PhPurchaseVM()
                                                {
                                                    //Code = ph.Code,
                                                    //ProductCode = p.Code,
                                                    ProductName = p.Name,
                                                    Photo = p.Photo,
                                                    Date = ph.PurchaseDate,
                                                    SalePrice = pd.SalesPrice,
                                                    Quantity = pd.Quantity
                                                }).ToList();
            if (purchaseHeads.Count != 0)
            {
                return purchaseHeads;
            }
            else
            {
                PhPurchaseVM purchaseVM = new PhPurchaseVM();
                purchaseHeads.Add(purchaseVM);
                return purchaseHeads;
            }
        }

        public List<PhPurchaseVM> GetProductDetailsByCode(int id, int ShopID)
        {
            List<PhPurchaseVM> purchaseHeads = (from ph in _db.PhPurchaseHeads
                                                join pd in _db.PhPurchaseDetails on ph.ID equals pd.PhPurchaseHead.ID
                                                join p in _db.PhProducts on pd.ProductID equals p.ID
                                                where ph.ID == id && ph.ShopID == ShopID && pd.Quantity > 0 && pd.SalesPrice > 0 && pd.CostPrice > 0
                                                select new PhPurchaseVM()
                                                {
                                                    //Code = ph.Code,
                                                    //ProductCode = p.Code,
                                                    ProductName = p.Name,
                                                    Photo = p.Photo,
                                                    Date = ph.PurchaseDate,
                                                    SalePrice = pd.SalesPrice,
                                                    CostPrice = pd.CostPrice,
                                                    Quantity = pd.Quantity,
                                                    //ReferenceCode = pd.Code
                                                }).ToList();
            if (purchaseHeads.Count != 0)
            {
                return purchaseHeads;
            }
            else
            {
                PhPurchaseVM purchaseVM = new PhPurchaseVM();
                purchaseHeads.Add(purchaseVM);
                return purchaseHeads;
            }

        }

        //public List<VSPurchaseVM> GetShop(string ShopCode)       
        //{            
        //    List<VSPurchaseVM> purchaseHeads = (from ph in _db.VSPurchaseHeads
        //                                      where ph.ShopCode == ShopCode && ph.Status == "Approved"
        //                                      join pd in _db.VSPurchaseDetails on ph.Code equals pd.HeadCode
        //                                      join p in _db.VSProducts on pd.ProductCode equals p.Code
        //                                      where pd.Quantity > 0 && pd.SalesPrice > 0 && pd.CostPrice > 0
        //                                      select new VSPurchaseVM()
        //                                      {
        //                                          Code = ph.Code,
        //                                          ProductCode = p.Code,
        //                                          ProductName = p.Name,
        //                                          Photo = p.Photo,
        //                                          Date = ph.Date,
        //                                          SalePrice=pd.SalesPrice
        //                                      }).ToList();
        //    if (purchaseHeads.Count != 0)
        //    {
        //        return purchaseHeads;
        //    }
        //    else
        //    {
        //        VSPurchaseVM purchaseVM = new VSPurchaseVM();
        //        purchaseHeads.Add(purchaseVM);
        //        return purchaseHeads;
        //    }

        //}

        //public List<VSPurchaseViewModel> GetApiAllByShop(string ShopCode)
        //{
        //    List<VSPurchaseViewModel> purchaseHeads = (from ph in _db.VSPurchaseHeads
        //                                      where ph.ShopCode == ShopCode
        //                                      //join pd in _db.PurchaseDetails on ph.Code equals pd.HeadCode
        //                                      join s in _db.VSSuppliers on ph.SupplierCode equals s.Code
        //                                      select new VSPurchaseViewModel()
        //                                      {
        //                                          Code = ph.Code,
        //                                          SupplierCode = ph.SupplierCode,
        //                                          SupplierName=s.Name,
        //                                          //ProductCode = p.Code,
        //                                          //ProductName = p.Name,
        //                                          //Photo=p.Photo,
        //                                          Date = ph.Date,
        //                                          //SalePrice=pd.SalesPrice, 
        //                                          //Status = ph.Status,
        //                                          NetAmount = (decimal)ph.NetAmount,
        //                                          Totalquantity = (decimal)ph.TotalQuantity
        //                                      }).ToList();
        //    if (purchaseHeads.Count != 0)
        //    {
        //        return purchaseHeads;
        //    }
        //    else
        //    {
        //        VSPurchaseViewModel purchaseVM = new VSPurchaseViewModel();
        //        purchaseHeads.Add(purchaseVM);
        //        return purchaseHeads;
        //    }

        //}

        public int SavePurchase(PhPurchaseHead purchaseHead)
        {
            using var _con = _dbAccess.GetConnection();
            int isSaved = 0;
            //try
            //{
            DataTable dt = new DataTable();
            dt.Columns.Add("HeadCode");
            dt.Columns.Add("ProductCode");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("CostPrice");
            dt.Columns.Add("TotalAmount");
            dt.Columns.Add("SalesPrice");
            dt.Columns.Add("Barcode");
            dt.Columns.Add("PacketBarcode");
            dt.Columns.Add("ExapiredDate");
            foreach (var row in purchaseHead.PhPurchaseDetails)
            {
                dt.Rows.Add
                    (
                    //row.Code,                    
                    row.ProductID,
                    row.Quantity,
                    row.CostPrice,
                    row.TotalAmount,
                    row.SalesPrice,
                    //row.SizeCode,
                    row.Barcode,
                    row.PacketBarcode,
                    row.ExapiredDate
                    //row.Color
                    );
            }

            isSaved = _con.Execute(
                 sql: Convert.ToString(Name.SP_PURCHASE_SAVE),
                     param: new
                     {
                         //Code = purchaseHead.Code,
                         //Date = purchaseHead.Date,
                         purchaseHead.InnvoiceNumber,
                         //SupplierCode = purchaseHead.SupplierCode,
                         purchaseHead.Remarks,
                         BranchCode = "",
                         //UserCode = purchaseHead.UserCode,
                         //ShopCode = purchaseHead.ShopCode,
                         //SqlDbType = SqlDbType.Structured,
                         //TypeName = "dbo.PurchaseDetailsType",
                         PurchaseDetailsType = dt,
                         //Action = "IN"
                     },
                     commandType: CommandType.StoredProcedure);

            //    SqlParameter[] parameterName = {
            //    new SqlParameter()
            //    {
            //        ParameterName = "@Code",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = purchaseHead.Code,
            //        Size = 15
            //    },
            //         new SqlParameter()
            //    {
            //        ParameterName = "@Date",
            //        SqlDbType = SqlDbType.DateTime,
            //        Value = purchaseHead.Date
            //    },
            //          new SqlParameter()
            //    {
            //        ParameterName = "@InnvoiceNumber",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = purchaseHead.InnvoiceNumber ??"",
            //        Size = 30
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@SupplierCode",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = purchaseHead.SupplierCode,
            //        Size = 15
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@Remarks",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = purchaseHead.Remarks ??"",
            //        Size = 100
            //    },


            //    new SqlParameter()
            //    {
            //        ParameterName = "@BranchCode",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = purchaseHead.BranchCode,
            //        Size = 15
            //    },
            //     new SqlParameter()
            //    {
            //        ParameterName = "@UserCode",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = purchaseHead.UserCode,
            //        Size = 15
            //    },
            //     new SqlParameter()
            //    {
            //        ParameterName = "@ShopCode",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = purchaseHead.ShopCode,
            //        Size = 15
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@PurchaseDetailsType",
            //        SqlDbType = SqlDbType.Structured,
            //        TypeName = "dbo.PurchaseDetailsType",
            //        Value = dt
            //    }
            //};

            //    int result = 0;//_db.Database.ExecuteSqlCommand("SP_PURCHASE_SAVE @Code,@Date,@InnvoiceNumber,@SupplierCode,@Remarks,@BranchCode,@UserCode,@ShopCode,@PurchaseDetailsType", parameterName);
            //    if (result > 0)
            //    {
            //        isSaved = true;
            //    }
            //}
            //catch (Exception ex) { }
            return isSaved;
        }

        public string Approve(string @Code, string BranchCode)
        {
            string result = "Failed !";
            //try
            //{
            //    SqlParameter[] sqlParameters ={
            //        new SqlParameter
            //        {
            //            ParameterName = "@Code",
            //            SqlDbType = SqlDbType.NVarChar,
            //            Value = Code,
            //            Size=15
            //        },
            //        new SqlParameter
            //        {
            //            ParameterName = "@BranchCode",
            //            SqlDbType = SqlDbType.NVarChar,
            //            Value = BranchCode,
            //            Size=15
            //        }
            //    };
            //   result = _db.Database.SqlQueryRaw<string>("SP_Purchase_Approve @Code,@BranchCode", sqlParameters).ToList<String>().FirstOrDefault();
            //}
            //catch (Exception ex) { }
            return result;
        }
    }
}
