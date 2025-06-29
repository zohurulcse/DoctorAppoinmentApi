
namespace ZHOSPITAL.Models.ViewModel
{
    public class CmnMenusPermissionModel
    {
        public int ID { get; set; }
        public string ModuleName { get; set; }
        public string ParentName { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public int ModuleID { get; set; }
        public int ShopID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public bool IsAdd { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsView { get; set; }
        public bool IsDelete { get; set; }
    }
}
