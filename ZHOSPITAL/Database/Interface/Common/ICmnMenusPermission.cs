using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Database.Interface.Common
{
    public interface ICmnMenusPermission
    {
        Task<int> SaveData(CmnMenusPermissionModel cmnMenusModel);

        Task<int> UpdateData(CmnMenusPermissionModel cmnMenusPermissionModel);
        //Task<int> DeleteData(int id);
        Task<List<CmnMenusPermissionModel>> GetAllData();

        //Task<CmnMenusPermissionModel> GetAllByID(int id);

        //Task<List<CmnMenusPermissionModel>> GetAllModule();

        Task<List<CmnMenusPermissionModel>> GetMenusPermission(int moduleID, int shopID, int roleID,int shopTypeID);

        //Task<List<CmnMenusPermissionModel>> GetMenuInfoList(int shopID, int roleID);
    }
}
