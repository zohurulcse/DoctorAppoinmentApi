namespace ZHOSPITAL.Models.ViewModel
{
    public class MenuInfoModel
    {
        public int MenuID { get; set; }
        public string headTitle { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
        public int ParentID { get; set; }
        public int LayerID { get; set; }
        public bool IsActive { get; set; }
        public string NavigationType { get; set; }
    }

    public class MenuInfoModelResponse : MenuInfoModel
    {
        //public List<MenuInfoModel> children { get; set; }
        public List<MenuInfoModelResponse> children { get; set; }
    }
}
