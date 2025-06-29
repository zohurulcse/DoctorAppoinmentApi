using System;
using System.Collections.Generic;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Models.CRM;
//using ZHOSPITAL.Areas.Pharmacy.ViewModel.API;
using ZHOSPITAL.Database.Base;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Repository.Common
{
    public class PhSupplierRepository : BaseRepository<PhSupplier>, IPhSupplierRepository
    {
        public PhSupplierRepository(ZHOSPITALDbContext db) : base(db)
        {
        }

        public List<PhSupplier> GetAll()
        {
            List<PhSupplier> suppliers = _db.PhSuppliers.ToList();
            return suppliers;
        }
        public List<PhSupplier> GetAll(int ShopID)
        {
            List<PhSupplier> suppliers = _db.PhSuppliers.Where(c => c.ShopID == ShopID).ToList();
            return suppliers;
        }
       
        //public List<VSSupplierViewModel> GetAllSupplier()
        //{
        //    List<VSSupplierViewModel> sizes = (from x in _db.VSSuppliers
        //                                       select new VSSupplierViewModel()
        //                                       {
        //                                           Name = x.Name,
        //                                           Status = x.Status,
        //                                       }).ToList();
        //    return sizes;
        //}
    }
}
