using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ZHOSPITAL.Areas.Pharmacy.Models.Sales;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhSalesDetailsRepository : BaseRepository<PhSalesDetails>, IPhSalesDetailsRepository
    {
        public PhSalesDetailsRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        //public List<VSSalesDetails> GetByHeadCode(string HeadCode)
        //{
        //    List<VSSalesDetails> salesDetails = _db.VSSalesDetails.Where(c => c.HeadCode == HeadCode).ToList();
        //    return salesDetails;
        //}
        //public List<VSSalesDetails> GetByHeadDetailsCode(string HeadCode, string DetailsCode)
        //{
        //    List<VSSalesDetails> purchaseDetails = _db.VSSalesDetails.Where(c => c.HeadCode == HeadCode && c.Code == DetailsCode).ToList();
        //    return purchaseDetails;
        //}
        public decimal ProductSalesQty(string SalesDetailsCode, string ProductCode)
        {
            //VSSalesDetailsRepository _salesDetailsRepository = new VSSalesDetailsRepository();
            //var SalesQty = _salesDetailsRepository.GetAll().Where(x => x.Code == SalesDetailsCode && x.ProductCode == ProductCode).Select(s => s.Quantity).Sum();
            //return SalesQty;
            return 0;
        }
        public decimal ProductStock_ProductCode_Wise(string BranchCode, string IssueCode, string ProductCode)
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
                        ParameterName = "@IssueCode",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = IssueCode,
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

                productStock = _db.Database.SqlQueryRaw<decimal>("SP_PRODUCT_SALES_STOCK @BranchCode,@IssueCode,@ProductCode", sqlParameters).FirstOrDefault();
            }
            catch (Exception ex) { }
            return productStock;
        }

        public decimal ProductAvgCost(string ProductCode, string ShopCode)
        {
            decimal productAvgCost = 0;
            try
            {
                SqlParameter[] sqlParameters ={
                    new SqlParameter
                    {
                        ParameterName = "@ProductCode",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = ProductCode,
                        Size=15
                    },
                    new SqlParameter
                    {
                        ParameterName = "@ShopCode",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = ShopCode,
                        Size=15
                    },                    
                };

                productAvgCost = _db.Database.SqlQueryRaw<decimal>("FNGetAvgCost @ProductCode,@ShopCode", sqlParameters).FirstOrDefault();
            }
            catch (Exception ex) { }
            return productAvgCost;
        }
       

        public int Remove(string Code)
        {
            int result = 0;
            SqlParameter Parameter = new SqlParameter("@Code", SqlDbType.NVarChar);
            Parameter.Value = Code;
            Parameter.Size = 15;

            result = 0;//_db.Database.ExecuteSqlCommand("SP_DELETE_PartsandServiceSalesDetails @Code", Parameter);

            return result;
        }

        //public bool RemoveByHeadCode(string Code)
        //{
        //    List<VSSalesDetails> purchaseDetails = _db.VSSalesDetails.Where(c => c.HeadCode == Code).ToList();
        //    bool result = RemoveRange(purchaseDetails);
        //    return result;
        //}

        //public List<VSSalesDetails> GetByHeadProductCode(string HeadCode, string ProductCode)
        //{
        //    List<VSSalesDetails> salesDetails = _db.VSSalesDetails.Where(c => c.HeadCode == HeadCode && c.ProductCode == ProductCode).ToList();
        //    return salesDetails;
        //}
    }
}
