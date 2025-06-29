using System;
using System.Collections.Generic;
using ZAPI.Database.Base;
using ZAPI.Database.Interface;
using ZAPI.Models.Setup;

namespace ZAPI.Database.Repository
{
    public class ShopTypeRepository : BaseRepository<ShopType>, IShopTypeRepository
    {
        public List<ShopType> GetAll(string CompanyCode)
        {
            List<ShopType> shopType = _db.ShopType.Where(c => c.CompanyCode == CompanyCode).ToList();
            return shopType;
        }
        public List<ShopType> GetAll(string CompanyCode, string Status)
        {
            List<ShopType> shopType = _db.ShopType.Where(c => c.CompanyCode == CompanyCode && c.Status == Status).ToList();
            return shopType;
        }
        public List<ShopType> GetSearch(string CompanyCode, string SearchValue)
        {
            SearchValue = SearchValue.ToLower();
            List<ShopType> shopType = _db.ShopType.Where(c => c.CompanyCode == CompanyCode && (c.Code.ToLower().Contains(SearchValue)
                                                                        || c.ShopTypeName.ToLower().Contains(SearchValue))).OrderBy(c => c.Code).ToList();
            return shopType;
        }
    }
}
