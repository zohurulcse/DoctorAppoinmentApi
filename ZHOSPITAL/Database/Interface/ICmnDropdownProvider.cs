using System;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Models.Setup;
using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Database.Interface.Common
{
    public interface ICmnDropdownProvider
    {
        Task<List<DropdownResponseModel>> GetAllData(int id,int shopID,string dropdownType);
    }
}
