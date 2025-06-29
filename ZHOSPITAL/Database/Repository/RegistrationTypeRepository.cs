using System;
using System.Collections.Generic;
using ZAPI.Database.Base;
using ZAPI.Database.Interface;
using ZAPI.Models.Setup;

namespace ZAPI.Database.Repository
{
    public class RegistrationTypeRepository : BaseRepository<RegistrationType>, IRegistrationTypeRepository
    {
        public List<RegistrationType> GetAll()
        {
            List<RegistrationType> customers = _db.RegistrationType.ToList();
            return customers;
        }
        public List<RegistrationType> GetAll(string Status)
        {
            List<RegistrationType> customers = _db.RegistrationType.Where(c => c.Status == Status).ToList();
            return customers;
        }


    }
}
