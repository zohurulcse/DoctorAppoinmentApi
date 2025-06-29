using System;
using System.Collections.Generic;
using ZHOSPITAL.Areas.Pharmacy.Models.CRM;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhCustomerRepository : BaseRepository<PhCustomer>, IPhCustomerRepository
    {
        public PhCustomerRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<PhCustomer> GetAll(int ShopID)
        {
            List<PhCustomer> customers = _db.PhCustomers.Where(c => c.ShopID == ShopID).ToList();
            return customers;
        }

        public List<PhCustomer> GetAll(int ShopID, string Status)
        {
            List<PhCustomer> customers = _db.PhCustomers.Where(c => c.ShopID == ShopID && c.Status == Status).ToList();
            return customers;
        }

        public PhCustomer CustomerLogin(int UserID, string Password)
        {
            PhCustomer customer = _db.PhCustomers.Where(c => c.UserID == UserID && c.Password == Password).FirstOrDefault();
            return customer;
        }       
      
    }
}
