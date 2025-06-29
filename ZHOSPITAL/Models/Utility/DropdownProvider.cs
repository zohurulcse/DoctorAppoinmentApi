
using System.Data;
using System.Web.Mvc;
using ZAPI.Areas.VarietiesStore;
using ZAPI.Database.Repository;
using ZAPI.Database.Repository.Authority;

namespace ZAPI.Models.Utility
{
    public class DropdownProvider
    {
        public List<SelectListItem> GetBranchs()
        {
            VSBranchRepository _repository = new VSBranchRepository();
            var Items = _repository.GetAll("COM000000001", "Active");
            var DropDownItems = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public List<SelectListItem> GetBanks()
        {
            BankRepository _repository = new BankRepository();
            var Items = _repository.GetAll("COM000000001", "Active");
            var DropDownItems = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public List<SelectListItem> GetBranchsWtihoutThis()
        {
            VSBranchRepository _repository = new VSBranchRepository();
            var Items = _repository.GetAll("COM000000001", "Active").Where(x => x.Code != "BRN0000000001");
            var DropDownItems = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public List<SelectListItem> GetRoles()
        {
            VSUserRoleRepository _repository = new VSUserRoleRepository();
            var Items = _repository.GetAll("COM000000001", "Active");
            var DropDownItems = new List<SelectListItem>();

            foreach (var role in Items)
            {
                var item = new SelectListItem() { Text = role.Name, Value = role.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public List<SelectListItem> GetParents()
        {
            MenuRepository _repository = new MenuRepository();
            var Items = _repository.GetAll("COM000000001").Where(c => (c.Type == "Parent" || c.Type == "Child-Parent") && c.Status == "Active").ToList();
            var DropDownItems = new List<SelectListItem>();

            foreach (var item in Items)
            {
                var data = new SelectListItem() { Text = item.Name + "(" + item.Module + "-" + item.Type + ")", Value = item.Code.ToString() };
                DropDownItems.Add(data);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });
            return DropDownItems;
        }

        public List<SelectListItem> GetGroups()
        {
            VSGroupRepository _repository = new VSGroupRepository();
            //var Items = _repository.GetAll("COM000000001", "Active");
            var Items = _repository.GetAll("SHS000000000001");
            var DropDownItems = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public List<SelectListItem> GetCategorys()
        {
            VSCategoryRepository _repository = new VSCategoryRepository();
            var Items = _repository.GetAll("SHS000000000001");
            var DropDownItems = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public List<SelectListItem> GetBrands()
        {
            VSBrandRepository _repository = new VSBrandRepository();
            var Items = _repository.GetAll("SHS000000000001");
            var DropDownItems = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public List<SelectListItem> GetStyles()
        {
            VSStyleRepository _repository = new VSStyleRepository();
            var Items = _repository.GetAll("SHS000000000001");
            var DropDownItems = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public List<SelectListItem> GetUnits()
        {
            VSUnitRepository _repository = new VSUnitRepository();
            var Items = _repository.GetAll("SHS000000000001");
            var DropDownItems = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public List<SelectListItem> GetSizes()
        {
            SizeRepository _repository = new SizeRepository();
            var Items = _repository.GetAll("SHS000000000001");
            var DropDownItems = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public List<SelectListItem> GetColors()
        {
            VSColorRepository _repository = new VSColorRepository();
            var Items = _repository.GetAll("Active");
            var DropDownItems = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.ColorName, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public List<SelectListItem> GetCategoryByGroup(string GroupCode)
        {
            VSCategoryRepository _repository = new VSCategoryRepository();
            var Items = _repository.GetAll("COM000000001", "Active", GroupCode);
            var DropDownItems = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }
            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });
            return DropDownItems;
        }

        public List<SelectListItem> GetYears()
        {
            var DropDownItems = new List<SelectListItem>();
            int startyear = 0;//Convert.ToInt16(ConfigurationSettings.AppSettings["StartYear"].ToString());

            int currentyear = DateTime.Now.Year + 1;
            for (int i = currentyear; i >= startyear; i--)
            {
                var item = new SelectListItem() { Text = i.ToString(), Value = i.ToString() };
                DropDownItems.Add(item);
            }
            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });
            return DropDownItems;
        }

        public List<SelectListItem> GetSuppliers()
        {
            VSSupplierRepository _repository = new VSSupplierRepository();
            var Items = _repository.GetAll("SHS000000000001");
            var DropDownItems = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public List<SelectListItem> GetCustomers()
        {
            VSCustomerRepository _repository = new VSCustomerRepository();
            var DropDownItems = new List<SelectListItem>();
            if ("SHS000000000001" != null)
            {
                var Items = _repository.GetAll("SHS000000000001", "Active");

                foreach (var Item in Items)
                {
                    var item = new SelectListItem() { Text = Item.Name + "(" + Item.Contact + ")", Value = Item.Code.ToString() };
                    DropDownItems.Add(item);
                }
            }


            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public IEnumerable<SelectListItem> GetEmployees()
        {
            VSEmployeeRepository repository = new VSEmployeeRepository();
            var Items = repository.GetAll("BRN000000000001");
            //var Items = repository.GetAll();
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code };
                dropDownList.Add(item);
            }
            dropDownList.Insert(0, new SelectListItem() { Text = @"-- Select --", Value = "" });
            return dropDownList;
        }

       
        public IEnumerable<SelectListItem> GetDepartments()
        {
            VSDepartmentRepository departmentRepository = new VSDepartmentRepository();
            var Items = departmentRepository.GetAll("COM000000001", "Active");
            var dropDownList = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code };
                dropDownList.Add(item);
            }
            dropDownList.Insert(0, new SelectListItem() { Text = @"-- Select --", Value = "" });
            return dropDownList;
        }

        public IEnumerable<SelectListItem> GetDesignations()
        {
            VSDesignationRepository designationRepository = new VSDesignationRepository();
            var Items = designationRepository.GetAll("COM000000001", "Active");
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code };
                dropDownList.Add(item);
            }

            dropDownList.Insert(0, new SelectListItem() { Text = @"-- Select --", Value = "" });
            return dropDownList;
        }

        public IEnumerable<SelectListItem> GetCompanies()
        {
            VSCompanyRepository companyRepository = new VSCompanyRepository();
            var Items = companyRepository.GetAll();
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code };
                dropDownList.Add(item);
            }

            dropDownList.Insert(0, new SelectListItem() { Text = @"-- Select --", Value = "" });
            return dropDownList;
        }

        public IEnumerable<SelectListItem> GetDivisions()
        {
            DivisionRepository divisionRepository = new DivisionRepository();
            var Items = divisionRepository.GetAll();
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.DivisionName, Value = Item.Code };
                dropDownList.Add(item);
            }

            dropDownList.Insert(0, new SelectListItem() { Text = @"-- সিলেক্ট --", Value = "" });
            return dropDownList;
        }
        //
        public IEnumerable<SelectListItem> GetDistrict()
        {
            DistrictRepository divisionRepository = new DistrictRepository();
            var Items = divisionRepository.GetAll();
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.DistrictName, Value = Item.Code };
                dropDownList.Add(item);
            }

            dropDownList.Insert(0, new SelectListItem() { Text = @"-- সিলেক্ট --", Value = "" });
            return dropDownList;
        }

        public IEnumerable<SelectListItem> GetDistrictByDivision(string divisionCode)
        {
            DistrictRepository districtRepository = new DistrictRepository();
            var Items = districtRepository.GetAll(divisionCode);
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.DistrictName, Value = Item.Code };
                dropDownList.Add(item);
            }

            dropDownList.Insert(0, new SelectListItem() { Text = @"-- সিলেক্ট --", Value = "" });
            return dropDownList;
        }

        public IEnumerable<SelectListItem> GetThana()
        {
            ThanaRepository divisionRepository = new ThanaRepository();
            var Items = divisionRepository.GetAll();
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.ThanaName, Value = Item.Code };
                dropDownList.Add(item);
            }

            dropDownList.Insert(0, new SelectListItem() { Text = @"-- সিলেক্ট --", Value = "" });
            return dropDownList;
        }

        public IEnumerable<SelectListItem> GetThanaByDistrict(string DistrictCode)
        {
            ThanaRepository thanaRepository = new ThanaRepository();
            var Items = thanaRepository.GetAll(DistrictCode);
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.ThanaName, Value = Item.Code };
                dropDownList.Add(item);
            }

            dropDownList.Insert(0, new SelectListItem() { Text = @"-- সিলেক্ট --", Value = "" });
            return dropDownList;
        }

        public IEnumerable<SelectListItem> GetBazar()
        {
            BazarRepository divisionRepository = new BazarRepository();
            var Items = divisionRepository.GetAll();
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.BazarName, Value = Item.Code };
                dropDownList.Add(item);
            }

            dropDownList.Insert(0, new SelectListItem() { Text = @"-- সিলেক্ট --", Value = "" });
            return dropDownList;
        }

        public IEnumerable<SelectListItem> GetBazarByThana(string ThanaCode)
        {
            BazarRepository divisionRepository = new BazarRepository();
            var Items = divisionRepository.GetAll(ThanaCode);
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.BazarName, Value = Item.Code };
                dropDownList.Add(item);
            }

            dropDownList.Insert(0, new SelectListItem() { Text = @"-- সিলেক্ট --", Value = "" });
            return dropDownList;
        }

        public IEnumerable<SelectListItem> GetShopType()
        {
            ShopTypeRepository divisionRepository = new ShopTypeRepository();
            var Items = divisionRepository.GetAll();
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.ShopTypeName, Value = Item.Code };
                dropDownList.Add(item);
            }

            dropDownList.Insert(0, new SelectListItem() { Text = @"-- সিলেক্ট --", Value = "" });
            return dropDownList;
        }

        public IEnumerable<SelectListItem> GetShop()
        {
            ShopSetupRepository divisionRepository = new ShopSetupRepository();
            var Items = divisionRepository.GetAll();
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.ShopName, Value = Item.Code };
                dropDownList.Add(item);
            }

            dropDownList.Insert(0, new SelectListItem() { Text = @"-- সিলেক্ট --", Value = "" });
            return dropDownList;
        }

        public IEnumerable<SelectListItem> GetBazarByShop(string BazarCode)
        {
            ShopSetupRepository divisionRepository = new ShopSetupRepository();
            var Items = divisionRepository.GetAll(BazarCode);
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.ShopName, Value = Item.Code };
                dropDownList.Add(item);
            }

            dropDownList.Insert(0, new SelectListItem() { Text = @"-- সিলেক্ট --", Value = "" });
            return dropDownList;
        }

        public IEnumerable<SelectListItem> GetRegistrationType()
        {
            RegistrationTypeRepository registrationTypeRepository = new RegistrationTypeRepository();
            var Items = registrationTypeRepository.GetAll("একটিভ");
            var dropDownList = new List<SelectListItem>();
            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.RegistrationTypeName, Value = Item.Code };
                dropDownList.Add(item);
            }

            dropDownList.Insert(0, new SelectListItem() { Text = @"-- সিলেক্ট --", Value = "" });
            return dropDownList;
        }

        public List<SelectListItem> GetProducts()
        {
            VSProductRepository _repository = new VSProductRepository();
            var Items = _repository.GetAllByStatus("COM000000001", "একটিভ");
            var DropDownItems = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }

        public List<SelectListItem> GetProductsByShop(string shopCode)
        {
            VSProductRepository _repository = new VSProductRepository();
            var Items = _repository.GetAllProductsByShopCode(shopCode);
            var DropDownItems = new List<SelectListItem>();

            foreach (var Item in Items)
            {
                var item = new SelectListItem() { Text = Item.Name, Value = Item.Code.ToString() };
                DropDownItems.Add(item);
            }

            DropDownItems.Insert(0, new SelectListItem() { Text = "-- Select --", Value = "" });

            return DropDownItems;
        }
    }
}