using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Data.SqlClient;
using System.Data;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductOrder;
using ZHOSPITAL.Areas.Pharmacy.Models;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Repository.ProductOrder
{
    public class PhProductOrderHeadRepository : BaseRepository<PhProductOrder>, IPhProductOrderHeadRepository
    {
        public PhProductOrderHeadRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        //public List<VSProductOrder> GetAll()
        //{
        //    List<VSProductOrder> productOder = _db.VSProductOrder.ToList();
        //    return productOder;
        //}
        //public List<VSPurchaseOrderHead> GetAll(string BranchCode)
        //{
        //    List<VSPurchaseOrderHead> purchaseHeads = _db.VSPurchaseOrderHead.Where(c => c.BranchCode == BranchCode).ToList();
        //    return purchaseHeads;
        //}
        //public List<VSPurchaseOrderHead> GetAll(string BranchCode, string Status)
        //{
        //    List<VSPurchaseOrderHead> purchaseHeads = _db.VSPurchaseOrderHead.Where(c => c.BranchCode == BranchCode && c.Status == Status).ToList();
        //    return purchaseHeads;
        //}

        //public bool Add(VSProductOrder productOrderHead, List<VSProductOrderDetail> productOrderDetail)
        //{
        //    bool isSaved = false;
        //    try
        //    {
        //        DataTable dt = new DataTable();               
        //        dt.Columns.Add("HeadCode");
        //        dt.Columns.Add("ProductCode");
        //        dt.Columns.Add("ProductName");
        //        dt.Columns.Add("Quantity");
        //        dt.Columns.Add("Price");
        //        dt.Columns.Add("Amount");
        //        dt.Columns.Add("Photo");
        //        dt.Columns.Add("ShopCode");
        //        foreach (var row in productOrderDetail)
        //        {
        //            dt.Rows.Add
        //                (                      
        //                row.HeadCode,
        //                row.ProductCode,
        //                row.ProductName,
        //                row.Quantity,
        //                row.Price,
        //                row.Amount,
        //                row.Photo,
        //                row.ShopCode
        //                );
        //        }

        //        SqlParameter[] parameterName = {
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Code",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderHead.Code,
        //            Size = 15
        //        },
        //             new SqlParameter()
        //        {
        //            ParameterName = "@Date",
        //            SqlDbType = SqlDbType.DateTime,
        //            Value = productOrderHead.OrderDate
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@CustomerCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderHead.CustomerCode,
        //            Size = 15
        //        },
        //          new SqlParameter()
        //        {
        //            ParameterName = "@Type",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = "INS",
        //            Size = 15
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@ProductOrderDetailsType",
        //            SqlDbType = SqlDbType.Structured,
        //            TypeName = "dbo.ProductOrderDetailsType",
        //            Value = dt
        //        },

        //    };

        //        int result = 0;//_db.Database.ExecuteSqlCommand("SP_PRODUCT_ORDER_SAVE @Code,@Date,@CustomerCode,@Type,@ProductOrderDetailsType", parameterName);
        //        if (result > 0)
        //        {
        //            isSaved = true;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return isSaved;
        //}

        //public bool IncrementProduct(VSProductOrder productOrderHead, VSProductOrderDetail productOrderDetail)
        //{
        //    bool isSaved = false;
        //    try
        //    {
        //        SqlParameter[] parameterName = {
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Code",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderHead.Code,
        //            Size = 15
        //        },
        //             new SqlParameter()
        //        {
        //            ParameterName = "@Date",
        //            SqlDbType = SqlDbType.DateTime,
        //            Value = productOrderHead.OrderDate
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@CustomerCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderHead.CustomerCode,
        //            Size = 15
        //        },

        //        new SqlParameter()
        //        {
        //            ParameterName = "@ProductCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderDetail.ProductCode,
        //            Size = 15
        //        },

        //        new SqlParameter()
        //        {
        //            ParameterName = "@Quantity",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = productOrderDetail.Quantity,
        //            Size = 15
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Type",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = "INC",
        //            Size = 15
        //        },
        //    };

        //        int result = 0;//_db.Database.ExecuteSqlCommand("SP_PRODUCT_CART_ORDER_SAVE @Code,@Date,@CustomerCode,@ProductCode,@Quantity,@Type", parameterName);
        //        if (result > 0)
        //        {
        //            isSaved = true;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return isSaved;
        //}
        //public bool DecrementProduct(VSProductOrder productOrderHead, VSProductOrderDetail productOrderDetail)
        //{
        //    bool isSaved = false;
        //    try
        //    {
        //        SqlParameter[] parameterName = {
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Code",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderHead.Code,
        //            Size = 15
        //        },
        //             new SqlParameter()
        //        {
        //            ParameterName = "@Date",
        //            SqlDbType = SqlDbType.DateTime,
        //            Value = productOrderHead.OrderDate
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@CustomerCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderHead.CustomerCode,
        //            Size = 15
        //        },

        //        new SqlParameter()
        //        {
        //            ParameterName = "@ProductCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderDetail.ProductCode,
        //            Size = 15
        //        },

        //        new SqlParameter()
        //        {
        //            ParameterName = "@Quantity",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = productOrderDetail.Quantity,
        //            Size = 15
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Type",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = "DEC",
        //            Size = 15
        //        },
        //    };

        //        int result = 0;//_db.Database.ExecuteSqlCommand("SP_PRODUCT_CART_ORDER_SAVE @Code,@Date,@CustomerCode,@ProductCode,@Quantity,@Type", parameterName);
        //        if (result > 0)
        //        {
        //            isSaved = true;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return isSaved;
        //}

        //public bool RemoveOrder(VSProductOrder productOrderHead, VSProductOrderDetail productOrderDetail)
        //{
        //    bool isSaved = false;
        //    try
        //    {
        //        SqlParameter[] parameterName = {
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Code",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderHead.Code,
        //            Size = 15
        //        },
        //             new SqlParameter()
        //        {
        //            ParameterName = "@Date",
        //            SqlDbType = SqlDbType.DateTime,
        //            Value = productOrderHead.OrderDate
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@CustomerCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderHead.CustomerCode,
        //            Size = 15
        //        },

        //        new SqlParameter()
        //        {
        //            ParameterName = "@ProductCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderDetail.ProductCode,
        //            Size = 15
        //        },

        //        new SqlParameter()
        //        {
        //            ParameterName = "@Quantity",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = productOrderDetail.Quantity,
        //            Size = 15
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Type",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = "REM",
        //            Size = 15
        //        },
        //    };

        //        int result = 0;//_db.Database.ExecuteSqlCommand("SP_PRODUCT_CART_ORDER_SAVE @Code,@Date,@CustomerCode,@ProductCode,@Quantity,@Type", parameterName);
        //        if (result > 0)
        //        {
        //            isSaved = true;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return isSaved;
        //}

        //public bool CheckOut(VSProductOrder productOrderHead, VSProductOrderDetail productOrderDetail)
        //{
        //    bool isSaved = false;
        //    try
        //    {
        //        SqlParameter[] parameterName = {
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Code",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderHead.Code,
        //            Size = 15
        //        },
        //             new SqlParameter()
        //        {
        //            ParameterName = "@Date",
        //            SqlDbType = SqlDbType.DateTime,
        //            Value = productOrderHead.OrderDate
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@CustomerCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderHead.CustomerCode,
        //            Size = 15
        //        },

        //        new SqlParameter()
        //        {
        //            ParameterName = "@ProductCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = productOrderDetail.ProductCode,
        //            Size = 15
        //        },

        //        new SqlParameter()
        //        {
        //            ParameterName = "@Quantity",
        //            SqlDbType = SqlDbType.Decimal,
        //            Value = productOrderDetail.Quantity,
        //            Size = 15
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Type",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = "CHK",
        //            Size = 15
        //        },
        //    };

        //        int result = 0;//_db.Database.ExecuteSqlCommand("SP_PRODUCT_CART_ORDER_SAVE @Code,@Date,@CustomerCode,@ProductCode,@Quantity,@Type", parameterName);
        //        if (result > 0)
        //        {
        //            isSaved = true;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return isSaved;
        //}
    }
}
