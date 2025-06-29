using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Data.SqlClient;
using System.Data;
using ZHOSPITAL.Areas.Pharmacy.Models.Sales;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Database.Utility;
using Dapper;
using ZHOSPITAL.Utility;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Areas.Pharmacy.ViewModel;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhSaleReturnHeadRepository : BaseRepository<PhSaleReturnHead>, IPhSaleReturnHeadRepository
    {
        private readonly IDBAccess _dbAccess;
        public PhSaleReturnHeadRepository(ZHOSPITALDbContext db, IDBAccess dbAccess) : base(db)
        {
            _dbAccess = dbAccess;
        }

        public IList<PhSaleReturnHead> GetDataByShop(int ShopID, string approvedStatus)
        {
            List<PhSaleReturnHead> purchaseHeads = (from ph in _db.PhSaleReturnHead
                                                  join cus in _db.PhCustomers on ph.CustomerID equals cus.ID
                                                  where ph.ShopID == ShopID && ph.ApproveStatus == approvedStatus
                                                  select new PhSaleReturnHead()
                                                  {
                                                      ID = ph.ID,
                                                      CustomerName = cus.Name,
                                                      CustomCode = ph.CustomCode,                                                     
                                                      Remarks = ph.Remarks,
                                                      Status = ph.Status,
                                                      ApproveStatus = ph.ApproveStatus,
                                                      NetAmount = ph.NetAmount,
                                                      TotalQuantity = ph.TotalQuantity,  
                                                      TotalAmount = ph.TotalAmount,
                                                      SaleReturnDate= ph.SaleReturnDate,
                                                      PhSaleReturnDetails = ph.PhSaleReturnDetails.Select(p => new PhSaleReturnDetails

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
                PhSaleReturnHead purchaseVM = new PhSaleReturnHead();
                purchaseHeads.Add(purchaseVM);
                return purchaseHeads;
            }

        }

        //Call from API
        public List<PhSaleReturnViewModel> GetAllByShop(int ShopID)
        {
            List<PhSaleReturnViewModel> saleHeads = (from ph in _db.PhSaleReturnHead
                                             where ph.ShopID == ShopID
                                                     join c in _db.PhCustomers on ph.CustomerID equals c.ID
                                             select new PhSaleReturnViewModel()
                                             {
                                                 //Code = ph.Code,
                                                 //CustomerCode = ph.CustomerCode,
                                                 CustomerName = c.Name,
                                                 //Date = ph.Date,
                                                 TotalAmount = (decimal)ph.TotalAmount,
                                                 Totalquantity = (decimal)ph.TotalQuantity
                                             }).ToList();
            if (saleHeads.Count != 0)
            {
                return saleHeads;
            }
            else
            {
                PhSaleReturnViewModel saleReturn = new PhSaleReturnViewModel();                
                saleHeads.Add(saleReturn);
                return saleHeads;
            }
           

        }

        public int SaveSaleReturn(PhSaleReturnHead saleReturnHead)
        {
            using var _con = _dbAccess.GetConnection();
            int isSaved = 0;
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("HeadCode");
                dt.Columns.Add("ProductCode");
                dt.Columns.Add("Rate");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Amount");
                dt.Columns.Add("ReferenceCode");
                foreach (var row in saleReturnHead.PhSaleReturnDetails)
                {
                    dt.Rows.Add(                      
                        row.ProductID,
                        row.Rate,
                        row.Quantity,
                        row.Amount,
                        row.SaleDetailID
                        );
                }

                isSaved = _con.Execute(
                  sql: Convert.ToString(StoreProcedure.Name.SP_Sale_RETURN_SAVE),
                param: new
                {
                    //Code = saleReturnHead.Code,
                    //Date = saleReturnHead.Date,
                    //CustomerCode = saleReturnHead.CustomerCode,
                    //ReferenceCode = saleReturnHead.ReferenceCode,
                    //BranchCode = saleReturnHead.BranchCode,
                    TotalQuantity = saleReturnHead.TotalQuantity,
                    TotalAmount = saleReturnHead.TotalAmount,
                    TotalDiscount = saleReturnHead.TotalDiscount,
                    NetAmount = saleReturnHead.NetAmount,
                    Remarks = saleReturnHead.Remarks,                   
                    //ShopCode = saleReturnHead.ShopCode,
                    SaleDetailsType = dt,

                },
                      commandType: CommandType.StoredProcedure);

            //    SqlParameter[] parameterName = {
            //    new SqlParameter()
            //    {
            //        ParameterName = "@Code",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = saleReturnHead.Code,
            //        Size = 15
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@CustomerCode",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = saleReturnHead.CustomerCode,
            //        Size = 15
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@Remarks",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = saleReturnHead.Remarks ??"",
            //        Size = 100
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@ReferenceCode",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = saleReturnHead.ReferenceCode,
            //        Size = 15
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@Date",
            //        SqlDbType = SqlDbType.DateTime,
            //        Value = saleReturnHead.Date
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@BranchCode",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = saleReturnHead.BranchCode,
            //        Size = 15
            //    },
            //     new SqlParameter()
            //    {
            //        ParameterName = "@TotalQuantity",
            //        SqlDbType = SqlDbType.Decimal,
            //        Value = saleReturnHead.TotalQuantity,
            //    },
            //     new SqlParameter()
            //    {
            //        ParameterName = "@TotalAmount",
            //        SqlDbType = SqlDbType.Decimal,
            //        Value = saleReturnHead.TotalAmount,
            //    },
            //     new SqlParameter()
            //    {
            //        ParameterName = "@GrandTotal",
            //        SqlDbType = SqlDbType.Decimal,
            //        Value = saleReturnHead.GrandTotal,
            //    },
            //     new SqlParameter()
            //    {
            //        ParameterName = "@TotalDiscountPercent",
            //        SqlDbType = SqlDbType.Decimal,
            //        Value = saleReturnHead.TotalDiscountPercent,
            //    },
            //     new SqlParameter()
            //    {
            //        ParameterName = "@TotalDiscount",
            //        SqlDbType = SqlDbType.Decimal,
            //        Value = saleReturnHead.TotalDiscount,
            //    },
            //     new SqlParameter()
            //    {
            //        ParameterName = "@VatPercent",
            //        SqlDbType = SqlDbType.Decimal,
            //        Value = saleReturnHead.VatPercent,
            //    },
            //     new SqlParameter()
            //    {
            //        ParameterName = "@VatAmount",
            //        SqlDbType = SqlDbType.Decimal,
            //        Value = saleReturnHead.VatAmount,
            //    },
            //     new SqlParameter()
            //    {
            //        ParameterName = "@NetAmount",
            //        SqlDbType = SqlDbType.Decimal,
            //        Value = saleReturnHead.NetAmount,
            //    },
            //     new SqlParameter()
            //    {
            //        ParameterName = "@Payable",
            //        SqlDbType = SqlDbType.Decimal,
            //        Value = saleReturnHead.Payable,
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@SaleReturnDetailsType",
            //        SqlDbType = SqlDbType.Structured,
            //        TypeName = "dbo.SaleReturnDetailsType",
            //        Value = dt
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "@ShopCode",
            //        SqlDbType = SqlDbType.NVarChar,
            //        Value = saleReturnHead.ShopCode,
            //        Size = 15
            //    }
            //};

            //    int result = 0;//_db.Database.ExecuteSqlCommand("SP_Sale_RETURN_SAVE @Code,@CustomerCode,@Remarks,@ReferenceCode,@Date,@BranchCode,@TotalQuantity,@TotalAmount,@GrandTotal,@TotalDiscountPercent,@TotalDiscount,@VatPercent,@VatAmount,@NetAmount,@Payable,@SaleReturnDetailsType,@ShopCode", parameterName);
            //    if (result > 0)
            //    {
            //        isSaved = true;
            //    }
            }
            catch (Exception ex) { }
            return isSaved;
        }
    }
}
