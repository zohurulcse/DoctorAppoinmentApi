using System;
using System.Collections.Generic;
using ZAPI.Database.Base;
using ZAPI.Database.Interface;
using ZAPI.Models.Setup;

namespace ZAPI.Database.Repository
{
    public class BankRepository : BaseRepository<Bank>, IBankRepository

    {
        public List<Bank> GetAll(string CompanyCode)
        {
            List<Bank> banks = _db.Bank.Where(c => c.CompanyCode == CompanyCode).ToList();
            return banks;
        }
        public List<Bank> GetAll(string CompanyCode, string Status)
        {
            List<Bank> banks = _db.Bank.Where(c => c.CompanyCode == CompanyCode && c.Status == Status).ToList();
            return banks;
        }
    }
}
