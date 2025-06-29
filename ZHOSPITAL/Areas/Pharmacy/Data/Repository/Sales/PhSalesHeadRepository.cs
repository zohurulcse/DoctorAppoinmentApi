
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ZHOSPITAL.Areas.Pharmacy.Models.Sales;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Database.Utility;
using ZHOSPITAL.Utility;
using Dapper;
using ZHOSPITAL.Areas.Pharmacy.ViewModel;


namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhSalesHeadRepository : BaseRepository<PhSalesHead>, IPhSalesHeadRepository
    {
        private readonly IDBAccess _dbAccess;
        public PhSalesHeadRepository(ZHOSPITALDbContext db, IDBAccess dbAccess) : base(db)
        {
            _dbAccess = dbAccess;
        }

        public List<PhSalesHead> GetAll(int shopID)
        {
            List<PhSalesHead> salesHeads = _db.PhSalesHeads.Where(c => c.ShopID == shopID).ToList();
            return salesHeads;
        }

        public IList<PhSalesHead> GetDataByShop(int ShopID, string approvedStatus)
        {
            List<PhSalesHead> purchaseHeads = (from ph in _db.PhSalesHeads
                                                  join cus in _db.PhCustomers on ph.CustomerID equals cus.ID
                                                  where ph.ShopID == ShopID && ph.ApproveStatus == approvedStatus
                                                  select new PhSalesHead()
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
                                                      Date = ph.Date,
                                                      PhSalesDetails = ph.PhSalesDetails.Select(p => new PhSalesDetails

                                                      {
                                                          ID = p.ID,
                                                          ProductName = _db.PhProducts.Where(x => x.ID == p.ProductID).Select(y => y.Name).FirstOrDefault(),
                                                          Quantity = p.Quantity,
                                                          Price = p.Price,                                                          
                                                          Amount = p.Amount
                                                      }).ToList()

                                                  }).ToList();
            if (purchaseHeads.Count != 0)
            {
                return purchaseHeads;
            }
            else
            {
                PhSalesHead purchaseVM = new PhSalesHead();
                purchaseHeads.Add(purchaseVM);
                return purchaseHeads;
            }

        }

        public int SaveSale(PhSalesHead salesHead)
        {
            using var _con = _dbAccess.GetConnection();
            int isSaved = 0;
            try
            {

                DataTable dt = new DataTable();
                dt.Columns.Add("HeadCode");
                dt.Columns.Add("ProductCode");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Price");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Barcode");
                foreach (var row in salesHead.PhSalesDetails)
                {
                    dt.Rows.Add
                        (                        
                            row.ProductID,
                            row.Quantity,
                            row.Price,
                            row.Amount,
                            row.Barcode
                        );
                }

                isSaved = _con.Execute(
                  sql: Convert.ToString(StoreProcedure.Name.SP_SALE_SAVE_API),
                param: new
                {
                    CustomCode = salesHead.CustomCode,
                    Date = salesHead.Date,
                    UserID = salesHead.UserID,
                    TotalQuantity=salesHead.TotalQuantity,
                    TotalAmount= salesHead.TotalAmount,
                    TotalDiscount= salesHead.TotalDiscount,
                    NetAmount= salesHead.NetAmount,
                    Remarks = salesHead.Remarks,
                    BranchCode = "",
                    ShopID = salesHead.ShopID,
                    SaleDetailsType = dt,

                      },
                      commandType: CommandType.StoredProcedure);


               
            }
            catch (Exception ex) { }
            return isSaved;
        }

        //public bool AddSalesHead(VSSalesHead salesHead)
        //{
        //    bool isSaved = false;
        //    try
        //    {
        //        SqlParameter[] parameterName = {
        //       new SqlParameter()
        //        {
        //            ParameterName = "@Code",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = salesHead.Code,
        //            Size = 15
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@CustomerCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = (object)salesHead.CustomerCode ?? DBNull.Value,
        //            Size = 15
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@EmployeeCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = salesHead.EmployeeCode,
        //            Size = 15
        //        },

        //        new SqlParameter()
        //        {
        //            ParameterName = "@VatPercent",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = (object)salesHead.VatPercent
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@VatAmount",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = salesHead.VatAmount
        //        },

        //        new SqlParameter()
        //        {
        //            ParameterName = "@GrandTotal",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = salesHead.GrandTotal,

        //        },
        //         new SqlParameter()
        //        {
        //            ParameterName = "@TotalDiscountPercent",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = salesHead.TotalDiscountPercent
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@TotalDiscount",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = salesHead.TotalDiscount
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@NetAmount",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = salesHead.NetAmount
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Adjust",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = salesHead.Adjust
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Payable",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = salesHead.Payable
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@PaymentType",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = (object)salesHead.PaymentType?? DBNull.Value,
        //            Size=20
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@PayAmount",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = salesHead.PayAmount
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@ServiceChargePercent",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = salesHead.ServiceChargePercent
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@ServiceChargeAmount",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = salesHead.ServiceChargeAmount
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@BankCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = (object)salesHead.BankCode?? DBNull.Value,
        //            Size=15
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@CardNumber",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = (object)salesHead.CardNumber?? DBNull.Value,
        //            Size=30
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@CashAmount",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = salesHead.CashAmount
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@CardAmount",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = salesHead.CardAmount
        //        },
        //         new SqlParameter()
        //        {
        //            ParameterName = "@ChangeAmount",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = salesHead.ChangeAmount
        //        },

        //           new SqlParameter()
        //        {
        //            ParameterName = "@BranchCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = salesHead.BranchCode,
        //            Size=15
        //        }
        //    };
        //        int result = 0;//_db.Database.ExecuteSqlCommand("SP_SalesHead_Insert @Code,@CustomerCode,@EmployeeCode,@VatPercent,@VatAmount,@GrandTotal,@TotalDiscountPercent,@TotalDiscount,@NetAmount,@Adjust,@Payable,@PaymentType,@PayAmount,@ServiceChargePercent,@ServiceChargeAmount,@BankCode,@CardNumber,@CashAmount,@CardAmount,@ChangeAmount,@BranchCode", parameterName);
        //        if (result > 0)
        //        {
        //            isSaved = true;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return isSaved;
        //}

        //public bool SaveFromApp(VSSalesHead saleHead, List<VSSalesDetails> saleDetails)
        //{
        //    bool isSaved = false;
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt.Columns.Add("HeadCode");
        //        dt.Columns.Add("ProductCode");
        //        dt.Columns.Add("Quantity");
        //        dt.Columns.Add("Price");
        //        dt.Columns.Add("Amount");
        //        dt.Columns.Add("Barcode");
        //        foreach (var row in saleDetails)
        //        {
        //            dt.Rows.Add
        //                (                       
        //                row.ProductID,
        //                row.Quantity,
        //                row.Price,
        //                row.Amount,
        //                row.Barcode
        //                );
        //        }

        //        SqlParameter[] parameterName = {
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Code",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = saleHead.Code,
        //            Size = 15
        //        },
        //             new SqlParameter()
        //        {
        //            ParameterName = "@Date",
        //            SqlDbType = SqlDbType.DateTime,
        //            Value = saleHead.Date
        //        },
        //              new SqlParameter()
        //        {
        //            ParameterName = "@CustomerCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = saleHead.CustomerCode,
        //            Size = 15
        //        },
        //              new SqlParameter()
        //        {
        //            ParameterName = "@EmployeeCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = saleHead.EmployeeCode ??"",
        //            Size = 30
        //        },
        //           new SqlParameter()
        //        {
        //            ParameterName = "@TotalQuantity",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = saleHead.TotalQuantity,
        //            Size = 30
        //        },
        //            new SqlParameter()
        //        {
        //            ParameterName = "@TotalAmount",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = saleHead.TotalAmount,
        //            Size = 30
        //        },
        //              new SqlParameter()
        //        {
        //            ParameterName = "@TotalDiscount",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = saleHead.TotalDiscount,
        //            Size = 30
        //        },
        //              new SqlParameter()
        //        {
        //            ParameterName = "@NetAmount",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = saleHead.NetAmount,
        //            Size = 30
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Remarks",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = saleHead.Remarks ??"",
        //            Size = 100
        //        },


        //        new SqlParameter()
        //        {
        //            ParameterName = "@BranchCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = saleHead.BranchCode,
        //            Size = 15
        //        },

        //         new SqlParameter()
        //        {
        //            ParameterName = "@ShopCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = saleHead.ShopCode,
        //            Size = 15
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@SaleDetailsType",
        //            SqlDbType = SqlDbType.Structured,
        //            TypeName = "dbo.SaleDetailsType",
        //            Value = dt
        //        }
        //    };

        //        int result = 0;//_db.Database.ExecuteSqlCommand("SP_SALE_SAVE_API @Code,@Date,@CustomerCode,@EmployeeCode,@TotalQuantity,@TotalAmount,@TotalDiscount,@NetAmount,@Remarks,@BranchCode,@ShopCode,@SaleDetailsType", parameterName);
        //        if (result > 0)
        //        {
        //            isSaved = true;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return isSaved;
        //}

        public string Quantity_Increment(string HeadCode, string ProductCode)
        {
            string result = "Failed !";
            try
            {
                SqlParameter[] parameterName = {
               new SqlParameter()
                {
                    ParameterName = "@HeadCode",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = HeadCode,
                    Size = 15
                },
                new SqlParameter()
                {
                    ParameterName = "@ProductCode",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = ProductCode,
                    Size = 15
                }
            };

                result = _db.Database.SqlQueryRaw<string>("SP_Sales_Quantity_Increment @HeadCode,@ProductCode", parameterName).ToList().FirstOrDefault();
            }
            catch (Exception ex) { }
            return result;
        }

        public string Quantity_Decrement(string HeadCode, string ProductCode)
        {
            string result = "Failed !";
            try
            {
                SqlParameter[] parameterName = {
               new SqlParameter()
                {
                    ParameterName = "@HeadCode",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = HeadCode,
                    Size = 15
                },
                new SqlParameter()
                {
                    ParameterName = "@ProductCode",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = ProductCode,
                    Size = 15
                }
            };

                result = _db.Database.SqlQueryRaw<string>("SP_Sales_Quantity_Decrement @HeadCode,@ProductCode", parameterName).ToList().FirstOrDefault();
            }
            catch (Exception ex) { }
            return result;
        }

        public decimal ProductStock_ProductCode_Wise(string BranchCode, string SalesCode, string ProductCode)
        {
            decimal productStock = 0;
            try
            {
                SqlParameter[] sqlParameters ={
                    new SqlParameter
                    {
                        ParameterName = "@BranchCode",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = BranchCode,
                        Size=15
                    },
                    new SqlParameter
                    {
                        ParameterName = "@SalesCode",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = SalesCode,
                        Size=15
                    },
                    new SqlParameter
                    {
                        ParameterName = "@ProductCode",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = ProductCode,
                        Size=15
                    }
                };

                productStock = _db.Database.SqlQueryRaw<decimal>("SP_ProductCode_Wise_Sales_Stock @BranchCode,@SalesCode,@ProductCode", sqlParameters).FirstOrDefault();
            }
            catch (Exception ex) { }
            return productStock;
        }

        public string Approve(string Code, string BranchCode)
        {
            string productStock = "Failed !";
            try
            {
                SqlParameter[] sqlParameters ={
                    new SqlParameter
                    {
                        ParameterName = "@Code",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = Code,
                        Size=15
                    },
                    new SqlParameter
                    {
                        ParameterName = "@BranchCode",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = BranchCode,
                        Size=15
                    }
                };

                productStock = _db.Database.SqlQueryRaw<string>("SP_PartsandServiceSales_Approve @Code,@BranchCode", sqlParameters).FirstOrDefault();
            }
            catch (Exception ex) { }
            return productStock;
        }
       

        //Call from API
        public List<PhSaleViewModel> GetAllByShop(int ShopID)
        {
            List<PhSaleViewModel> saleHeads = (from ph in _db.PhSalesHeads
                                               where ph.ShopID == ShopID
                                               join c in _db.PhCustomers on ph.CustomerID equals c.ID
                                                     select new PhSaleViewModel()
                                                     {                                                         
                                                        // CustomerCode = ph.CustomerCode,  
                                                         CustomerName = c.Name,
                                                         Date = ph.Date,                                                        
                                                         TotalAmount = (decimal)ph.TotalAmount,
                                                         Totalquantity = (decimal)ph.TotalQuantity
                                                     }).ToList();
            return saleHeads;

        }

        public List<PhSaleDetailsViewModel> GetProductDetailsByCode(int Code, int ShopID)
        {
            List<PhSaleDetailsViewModel> purchaseHeads = (from ph in _db.PhSalesHeads
                                                 join pd in _db.PhSalesDetails on ph.ID equals pd.PhSalesHead.ID
                                              join p in _db.PhProducts on pd.ProductID equals p.ID
                                              where ph.ID == Code && ph.ShopID == ShopID && pd.Quantity > 0 && pd.Price > 0
                                              select new PhSaleDetailsViewModel()
                                              {       
                                                  //Code = pd.Code,
                                                  //ProductCode = p.Code,
                                                  ProductName = p.Name,                                               
                                                  Price = (double)pd.Price,                                                 
                                                  Quantity = (int)pd.Quantity,                                                 
                                              }).ToList();
            return purchaseHeads;

        }

    }
}
