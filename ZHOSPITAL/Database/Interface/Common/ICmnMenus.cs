using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Database.Interface.Common
{
    public interface ICmnMenus
    {
        Task<int> SaveData(CmnMenusModel cmnMenusModel);

        Task<int> UpdateData(int id,CmnMenusModel cmnMenusModel);
        Task<int> DeleteData(int id);
        Task<List<CmnMenusModel>> GetAllData();

        Task<List<CmnMenusModel>> GetAllByID(int id);

        Task<List<CmnMenusModuleModel>> GetAllModule();

        Task<List<MenuInfoModelResponse>> GetMenuInfoModel(int shopID, int roleID);

        Task<List<MenuInfoModelResponse>> GetMenuInfoList(int shopID, int roleID);

        Task<List<CmnMenusModel>> GetMenuSlNo(int shopID);
    }
}
