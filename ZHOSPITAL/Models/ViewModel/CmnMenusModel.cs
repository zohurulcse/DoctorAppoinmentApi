
namespace ZHOSPITAL.Models.ViewModel
{
    public class CmnMenusModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ModuleName { get; set; }
        public string ParentName { get; set; }
        public int ModuleID { get; set; }
        public int ParentID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string NavigationType { get; set; }
        public string AnuglarUrl { get; set; }
        public string Path { get; set; }
        public bool Active { get; set; }
        public string HeadTitle { get; set; }
        public int ShopTypeID { get; set; }
        public string ShopTypeName { get; set; }
        public int ShopID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public int SLNo { get; set; }
        public string Icon { get; set; }
        //public bool IsAdd { get; set; }
        //public bool IsUpdate { get; set; }
        //public bool IsView { get; set; }
        //public bool IsDelete { get; set; }
        public virtual List<CmnMenusModel> children { get; set; }
    }
}
