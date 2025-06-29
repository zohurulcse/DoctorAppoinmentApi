using System;
using ZHOSPITAL.Areas.Pharmacy.ViewModel;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Models.Setup;
using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public interface IPhDropdownProvider 
    {
        Task<List<PhResponseModel>> GetAllData(int id,int shopID,string dropdownType);
    }
}
