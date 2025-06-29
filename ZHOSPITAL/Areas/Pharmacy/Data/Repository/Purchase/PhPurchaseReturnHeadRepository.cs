using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Data;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Purchase;
using System.Drawing;
using ZHOSPITAL.Utility;
using ZHOSPITAL.Database.Utility;
using Dapper;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Repository.Purchase
{
    public class PhPurchaseReturnHeadRepository : BaseRepository<PhPurchaseReturnHead>, IPhPurchaseReturnHeadRepository
    {

        private readonly IDBAccess _dbAccess;
        public PhPurchaseReturnHeadRepository(ZHOSPITALDbContext db, IDBAccess dbAccess) : base(db)
        {
            _dbAccess = dbAccess;
        }

        public List<PhPurchaseReturnHead> GetDataByShop(int ShopID,string approvedStatus)
        {
            List<PhPurchaseReturnHead> purchaseHeads = (from ph in _db.PhPurchaseReturnHeads
                                                  join sup in _db.PhSuppliers on ph.SupplierID equals sup.ID
                                                  where ph.ShopID == ShopID && ph.ApproveStatus == approvedStatus
                                                        select new PhPurchaseReturnHead()
                                                  {
                                                      ID = ph.ID,
                                                      SupplierName = sup.Name,
                                                      CustomCode = ph.CustomCode,
                                                      //InnvoiceNumber = ph.InnvoiceNumber,
                                                      Remarks = ph.Remarks,
                                                      Status = ph.Status,
                                                      ApproveStatus = ph.ApproveStatus,
                                                      TotalAmount = ph.TotalAmount,
                                                      TotalQuantity = ph.TotalQuantity,
                                                      Date = ph.Date,                                                     
                                                      PhPurchaseReturnDetails = ph.PhPurchaseReturnDetails.Select(p => new PhPurchaseReturnDetails

                                                      {
                                                          ID = p.ID,
                                                          ProductName = _db.PhProducts.Where(x => x.ID == p.ProductID).Select(y => y.Name).FirstOrDefault(),
                                                          Quantity = p.Quantity,
                                                          Rate = p.Rate,                                                         
                                                          Amount = p.Amount
                                                      }).ToList()

                                                  }).ToList();
            if (purchaseHeads.Count != 0)
            {
                return purchaseHeads;
            }
            else
            {
                PhPurchaseReturnHead purchaseVM = new PhPurchaseReturnHead();
                purchaseHeads.Add(purchaseVM);
                return purchaseHeads;
            }

        }

        //public List<VSPurchaseReturnHead> GetAll(string BranchCode)
        //{
        //    List<VSPurchaseReturnHead> bankAccounts = _db.VSPurchaseReturnHeads.Where(c => c.BranchCode == BranchCode).ToList();
        //    return bankAccounts;
        //}

        //public string CheckPurchaseReturnQuantity(decimal existsPurchaeReturnQuantity)
        //{
        //    return "Already Returyn '"+ existsPurchaeReturnQuantity + "'";            
        //}

        ////Call from API
        //public List<VSPurchaseReturnViewModel> GetAllByShop(string ShopCode)
        //{
        //    List<VSPurchaseReturnViewModel> purchaseHeads = (from ph in _db.VSPurchaseReturnHeads
        //                                             where ph.ShopCode == ShopCode
        //                                             //join pd in _db.PurchaseDetails on ph.Code equals pd.HeadCode
        //                                             join s in _db.VSSuppliers on ph.SupplierCode equals s.Code
        //                                             select new VSPurchaseReturnViewModel()
        //                                             {
        //                                                 Code = ph.Code,
        //                                                 SupplierCode = ph.SupplierCode,
        //                                                 SupplierName = s.Name,
        //                                                 //ProductCode = p.Code,
        //                                                 //ProductName = p.Name,
        //                                                 //Photo=p.Photo,
        //                                                 Date = ph.Date,
        //                                                 //SalePrice=pd.SalesPrice, 
        //                                                 //Status = ph.Status,
        //                                                 TotalAmount = (decimal)ph.TotalAmount,
        //                                                 Totalquantity = (decimal)ph.TotalQuantity
        //                                             }).ToList();
        //    if (purchaseHeads.Count != 0)
        //    {
        //        return purchaseHeads;
        //    }
        //    else
        //    {
        //        VSPurchaseReturnViewModel purchaseVM = new VSPurchaseReturnViewModel();
        //        purchaseHeads.Add(purchaseVM);
        //        return purchaseHeads;
        //    }

        //}

        public int SavePurchaseReturn(PhPurchaseReturnHead purchaseReturnHead)
        {
            using var _con = _dbAccess.GetConnection();
            int isSaved = 0;
            //try
            //{
            DataTable dt = new DataTable();
            dt.Columns.Add("HeadCode");
            dt.Columns.Add("ProductCode");
            dt.Columns.Add("Rate");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Amount");
            dt.Columns.Add("ReferenceCode");
            foreach (var row in purchaseReturnHead.PhPurchaseReturnDetails)
            {
                dt.Rows.Add(
                    row.ProductID,
                    row.Rate,
                    row.Quantity,
                    row.Amount
                    );
            }

            isSaved = _con.Execute(
               sql: Convert.ToString(StoreProcedure.Name.SP_PURCHASE_RETURN_SAVE),
                   param: new
                   {
                       //Code = purchaseReturnHead.Code,
                       purchaseReturnHead.Date,
                       //ReferenceCode = purchaseReturnHead.ReferenceCode,
                       //SupplierCode = purchaseReturnHead.SupplierCode,
                       purchaseReturnHead.Remarks,
                       BranchCode = "",
                       //ShopCode = purchaseReturnHead.ShopCode,
                       PurchaseReturnDetailsType = dt,

                   },
                   commandType: CommandType.StoredProcedure);

            //    SqlParameter[] parameterName = {
            //    new SqlParameter()
            //    {
            //        ParameterName = "@Code",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = purchaseReturnHead.Code,
            //        Size = 15
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@SupplierCode",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = purchaseReturnHead.SupplierCode,
            //        Size = 15
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@Remarks",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = purchaseReturnHead.Remarks ??"",
            //        Size = 100
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@ReferenceCode",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = purchaseReturnHead.ReferenceCode,
            //        Size = 15
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@Date",
            //        SqlDbType = SqlDbType.DateTime,
            //        Value = purchaseReturnHead.Date
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@BranchCode",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = purchaseReturnHead.BranchCode,
            //        Size = 15
            //    },
            //     new SqlParameter()
            //    {
            //        ParameterName = "@ShopCode",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = purchaseReturnHead.ShopCode,
            //        Size = 15
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@PurchaseReturnDetailsType",
            //        SqlDbType = SqlDbType.Structured,
            //        TypeName = "dbo.PurchaseReturnDetailsType",
            //        Value = dt
            //    }
            //};

            //    int result = 0;//_db.Database.ExecuteSqlCommand("SP_PURCHASE_RETURN_SAVE @Code,@SupplierCode,@Remarks,@ReferenceCode,@Date,@BranchCode,@ShopCode,@PurchaseReturnDetailsType", parameterName);
            //    if (result > 0)
            //    {
            //        isSaved = true;
            //    }
            //}
            //catch (Exception ex) { }
            return isSaved;
        }
    }
}
