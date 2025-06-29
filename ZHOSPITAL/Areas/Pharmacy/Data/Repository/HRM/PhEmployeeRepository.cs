using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ZHOSPITAL.Areas.Pharmacy.Models.HRM;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhEmployeeRepository : BaseRepository<PhEmployee>, IPhEmployeeRepository
    {
        public PhEmployeeRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<PhEmployee> GetAll(int shopID)
        {
            List<PhEmployee> employees =new List<PhEmployee>();
            try
            {
                employees = _db.PhEmployees.Where(c => c.ShopID == shopID).ToList();
            }
            catch (Exception ex){ }
            return employees;
        }
    }
}
