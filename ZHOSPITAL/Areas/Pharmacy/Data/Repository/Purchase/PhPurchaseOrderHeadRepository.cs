using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Data.SqlClient;
using System.Data;
using ZHOSPITAL.Areas.Pharmacy.Models.Inventory;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Purchase;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Repository.Purchase
{
    public class PhPurchaseOrderHeadRepository : BaseRepository<PhPurchaseOrderHead>, IPhPurchaseOrderHeadRepository
    {
        public PhPurchaseOrderHeadRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

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

        //public bool Add(VSPurchaseOrderHead purchaseOrderHead, List<VSPurchaseOrderDetails> purchaseOrderDetail)
        //{
        //    bool isSaved = false;
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        //dt.Columns.Add("DetailCode");
        //        dt.Columns.Add("HeadCode");
        //        dt.Columns.Add("ProductCode");
        //        dt.Columns.Add("Quantity");
        //        dt.Columns.Add("UnitPrice");
        //        dt.Columns.Add("TotalPrice");
        //        dt.Columns.Add("SizeCode");
        //        dt.Columns.Add("Color");
        //        foreach (var row in purchaseOrderDetail)
        //        {
        //            dt.Rows.Add
        //                (
        //                //row.Code,
        //                //row.HeadCode,
        //                row.ProductID,
        //                row.Quantity,
        //                row.UnitPrice,
        //                row.TotalPrice                       
        //                );
        //        }

        //        SqlParameter[] parameterName = {
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Code",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = purchaseOrderHead.Code,
        //            Size = 15
        //        },
        //             new SqlParameter()
        //        {
        //            ParameterName = "@Date",
        //            SqlDbType = SqlDbType.DateTime,
        //            Value = purchaseOrderHead.Date
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@SupplierCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = purchaseOrderHead.SupplierCode,
        //            Size = 15
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@Remarks",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = purchaseOrderHead.Remarks ??"",
        //            Size = 100
        //        },


        //        new SqlParameter()
        //        {
        //            ParameterName = "@BranchCode",
        //            SqlDbType = SqlDbType.NVarChar,
        //            Value = purchaseOrderHead.BranchCode,
        //            Size = 15
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName = "@PurchaseOrderDetailsType",
        //            SqlDbType = SqlDbType.Structured,
        //            TypeName = "dbo.PurchaseOrderDetailsType",
        //            Value = dt
        //        }
        //    };

        //        int result = 0;//_db.Database.ExecuteSqlCommand("SP_PURCHASEORDER_SAVE @Code,@Date,@SupplierCode,@Remarks,@BranchCode,@PurchaseOrderDetailsType", parameterName);
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
