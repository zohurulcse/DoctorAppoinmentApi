using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ZHOSPITAL.Areas.Pharmacy.Models.Account;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class VSReceivePaymentRepository : BaseRepository<PhReceivePayment>, IPhReceivePayment
    {
        public VSReceivePaymentRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        //public List<VSReceivePayment> GetAll(string CompanyCode)
        //{
        //    List<VSReceivePayment> receivePayment = _db.ReceivePayment.Where(c => c.CompanyCode == CompanyCode).ToList();
        //    return receivePayment;
        //}
        //public List<Customer> SearchCustomer(string CompanyCode, string searchValue)
        //{
        //    List<ReceivePayment> customers = new List<ReceivePayment>();
        //    try
        //    {
        //        searchValue = searchValue.ToLower();
        //        customers = _db.ReceivePayment.Where(c => c.CompanyCode == CompanyCode && (c.Code.ToLower().Contains(searchValue) || c.Name.ToLower().Contains(searchValue) || c.Contact.ToLower().Contains(searchValue) || c.Email.ToLower().Contains(searchValue))).Take(10).ToList();
        //    }
        //    catch(Exception ex) { }
        //    return customers;
        //}

        public bool Add(PhReceivePayment receivePayment)
        {
            bool isSaved = false;
            try
            {
                SqlParameter[] parameterName = {
                new SqlParameter()
                {
                    ParameterName = "@Code",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = receivePayment.Code,
                    Size = 15
                },
                new SqlParameter()
                {
                    ParameterName = "@ReferenceNo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = receivePayment.LedgerCode,
                    Size = 15
                },
                 new SqlParameter()
                {
                    ParameterName = "@InvoiceNo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = receivePayment.InvoiceNo,
                    Size = 15
                },
                  new SqlParameter()
                {
                    ParameterName = "@TransactionDate",
                    SqlDbType = SqlDbType.DateTime,
                    Value = receivePayment.TransactionDate
                },
               
                new SqlParameter()
                {
                    ParameterName = "@PaymentTypeID",
                    SqlDbType = SqlDbType.Int,
                    Value = receivePayment.PaymentType,
                    Size = 15
                },
          
                new SqlParameter()
                {
                    ParameterName = "@BankCode",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = receivePayment.BankCode ??"",
                    Size = 15
                },
                 new SqlParameter()
                {
                    ParameterName = "@BankAccountNo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = receivePayment.BankAccountNo ??"",
                    Size = 15
                },
                  new SqlParameter()
                {
                    ParameterName = "@BankChequeNo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = receivePayment.BankChequeNo ??"",
                    Size = 15
                },
                   new SqlParameter()
                {
                    ParameterName = "@PaymodeID",
                    SqlDbType = SqlDbType.Int,
                    Value = receivePayment.PaymodeID,
                    Size = 15
                },
                    new SqlParameter()
                {
                    ParameterName = "@Amount",
                    SqlDbType = SqlDbType.Decimal,
                    Value = receivePayment.Amount,
                    Size = 15
                },
                 new SqlParameter()
                {
                    ParameterName = "@Remarks",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = receivePayment.Remarks ??"",
                    Size = 100
                }
            };

                int result = 0;//_db.Database.ExecuteSqlCommand("SP_ReceivePayment_Save @Code,@ReferenceNo,@InvoiceNo,@TransactionDate,@PaymentTypeID,@BankCode,@BankAccountNo,@BankChequeNo,@PaymodeID,@Amount,@Remarks,@CompanyCode", parameterName);
                if (result > 0)
                {
                    isSaved = true;
                }
            }
            catch (Exception ex) {
                
            }
            return isSaved;
        }
    }
}
