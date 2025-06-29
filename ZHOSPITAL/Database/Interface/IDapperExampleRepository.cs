using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Models.Setup;
using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Database.Interface
{
    public interface IDapperExampleRepository 
    {
        public Task<int> SaveData(string name);
        public Task<int> UpdateData(LoginResponseModel loginResponseModel);
        public Task<List<LoginResponseModel>> GetAllData();
        public Task<LoginResponseModel> GetData(int id);
    }
}
