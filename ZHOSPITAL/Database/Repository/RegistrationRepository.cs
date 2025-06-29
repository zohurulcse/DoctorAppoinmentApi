using System;
using System.Collections.Generic;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Database.Interface;
using ZHOSPITAL.Models.Setup;
using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Database.Repository
{
    public class RegistrationRepository : BaseRepository<Registration>, IRegistrationRepository
    {
        public RegistrationRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<Registration> GetAll()
        {
            List<Registration> registration = _db.Registration.ToList();
            return registration;
        }
        public List<CommonVM> GetAllByRegistrationCode(int id)
        {
            var registration = (from r in _db.Registration.Where(c => c.ID == id)
                                join rt in _db.RegistrationType on r.RegistrationTypeID equals rt.ID
                                join div in _db.Division on r.ID equals div.ID
                                join dis in _db.District on r.ID equals dis.ID
                                join th in _db.Thana on r.ID equals th.ID                                
                                select new CommonVM
                                {
                                    RegistrationCode = r.CustomCode,
                                    RegistrationName = r.Name,
                                    RegistrationTypeName = rt.RegistrationTypeName,
                                    DivisionName = div.DivisionName,
                                    DistrictName = dis.DistrictName,
                                    ThanaName = th.ThanaName,                                 
                                    PresendAddress = r.PresendAddress,
                                    PermanantAddress = r.PermanantAddress,
                                    FatherName = r.FatherName,
                                    ContactNo = r.Contact
                                }).ToList();
            return registration;
        }
        //public List<VSProductOrderVM> GetAll(string Status)
        //{
        //    List<VSProductOrderVM> productOrder = (from r in _db.Registration
        //                                           join rt in _db.RegistrationType on r.RegistrationTypeID equals rt.ID
        //                                           where r.Status == Status
        //                                           select new VSProductOrderVM()
        //                                           {
        //                                               Code = r.CustomCode,
        //                                               Name = r.Name,
        //                                               PresendAddress = r.PresendAddress,
        //                                               PermanantAddress = r.PermanantAddress,
        //                                               FatherName = r.FatherName,
        //                                               Contact = r.Contact,
        //                                               RegistrationType = rt.RegistrationTypeName
        //                                           }).ToList();
        //    return productOrder;

        //}

        public List<CommonVM> GetAllByShopCode(int shopCode)
        {
            List<CommonVM> productOrder = (from r in _db.Registration
                                           where r.ShopID == shopCode
                                           select new CommonVM()
                                           {
                                               RegistrationCode = r.CustomCode,
                                               RegistrationName = r.Name,
                                               PresendAddress = r.PresendAddress,
                                               PermanantAddress = r.PermanantAddress,
                                               FatherName = r.FatherName,
                                               ContactNo = r.Contact,
                                               Email = r.Email
                                           }).ToList();
            return productOrder;

        }
        public Registration CustomerLogin(int UserID, string Password)
        {
            Registration registration = _db.Registration.Where(c => c.UserID == UserID && c.Password == Password).FirstOrDefault();
            return registration;
        }
    }
}
