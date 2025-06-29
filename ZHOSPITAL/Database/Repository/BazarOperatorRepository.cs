using System;
using System.Collections.Generic;
using ZAPI.Areas.VarietiesStore.ViewModel;
using ZAPI.Database.Base;
using ZAPI.Database.Interface;
using ZAPI.Models.Setup;

namespace ZAPI.Database.Repository
{
    public class BazarOperatorRepository : BaseRepository<BazarOperator>, IBazarOperatorRepository
    {
        public List<BazarOperator> GetAll()
        {
            List<BazarOperator> bazarOperators = _db.BazarOperator.OrderByDescending(x => x.Code).Distinct().ToList();
            return bazarOperators;
        }
        public List<BazarOperator> GetAllUnApproved()
        {
            List<BazarOperator> bazarOperators = _db.BazarOperator.Where(x => x.IsApproved == false).OrderByDescending(x => x.Code).Distinct().ToList();
            return bazarOperators;
        }
        public List<BazarOperator> GetUnApprovedData(string Code)
        {
            List<BazarOperator> bazarOperators = _db.BazarOperator.Where(x => x.IsApproved == false && x.Code == Code).OrderByDescending(x => x.Code).Distinct().ToList();
            return bazarOperators;
        }
        //public List<BazarOperator> GetAll(string BazarCode)
        //{
        //    List<BazarOperator> bazarOperators = _db.BazarOperator.Where(c => c.BazarCode == BazarCode).ToList();
        //    return bazarOperators;
        //}
        public List<BazarOperatorVM> GetAll(string BazarCode)
        {
            List<BazarOperatorVM> productOrder = (from oh in _db.BazarOperator.Where(x => x.BazarCode == BazarCode)
                                                  join bz in _db.Bazar on oh.BazarCode equals bz.Code
                                                  join rol in _db.UserRoles on oh.RoleCode equals rol.Code
                                                  select new BazarOperatorVM()
                                                  {
                                                      Code = oh.Code,
                                                      OperatorName = oh.OperatorName,
                                                      ContactNo = oh.ContactNo,
                                                      PermanantAddress = oh.Address,
                                                      BazarName = bz.BazarName,
                                                      RoleName = rol.Name,
                                                      Photo = bz.Photo
                                                  }).OrderByDescending(x => x.Code).ToList();
            return productOrder;

        }
        public List<BazarOperator> GetShopInfo(string ShopCode)
        {
            List<BazarOperator> bazarOperators = _db.BazarOperator.Where(c => c.Code == ShopCode).ToList();
            return bazarOperators;
        }
        public List<BazarOperator> GetAll(string CompanyCode, string Status)
        {
            List<BazarOperator> bazarOperators = _db.BazarOperator.Where(c => c.CompanyCode == CompanyCode && c.Status == Status).ToList();
            return bazarOperators;
        }

        public BazarOperator CustomerLogin(string UserID, string Password)
        {
            BazarOperator bazarOperators = _db.BazarOperator.Where(c => c.UserID == UserID && c.Password == Password).FirstOrDefault();
            return bazarOperators;
        }
        public List<BazarOperator> SearchCustomer(string CompanyCode, string searchValue)
        {
            List<BazarOperator> bazarOperators = new List<BazarOperator>();
            try
            {
                searchValue = searchValue.ToLower();
                bazarOperators = _db.BazarOperator.Where(c => c.CompanyCode == CompanyCode && (c.Code.ToLower().Contains(searchValue) || c.OperatorName.ToLower().Contains(searchValue) || c.HelpLine.ToLower().Contains(searchValue) || c.Email.ToLower().Contains(searchValue))).Take(10).ToList();
            }
            catch (Exception ex) { }
            return bazarOperators;
        }
    }
}
