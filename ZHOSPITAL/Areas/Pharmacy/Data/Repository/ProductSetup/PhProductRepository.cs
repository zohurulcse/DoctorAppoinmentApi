using Dapper;
using Microsoft.CodeAnalysis;
using System.Data;
using System.Drawing;
using System.Text;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Database.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats;
using System.IO;
using System.Threading.Tasks;
using ZHOSPITAL.Utility;
using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhProductRepository : BaseRepository<PhProduct>, IPhProductRepository
    {
        private readonly IDBAccess _dbAccess;
        public PhProductRepository(ZHOSPITALDbContext db, IDBAccess dbAccess) : base(db)
        {
            _dbAccess = dbAccess;
        }

        public List<PhProduct> GetAllProductsByShopCode(int shopID)
        {
            List<PhProduct> products = (from x in _db.PhProducts.Where(c => c.ShopID == shopID)
                                        join cat in _db.PhCategorys on x.CategoryID equals cat.ID
                                        join br in _db.PhBrand on x.BrandID equals br.ID
                                        join st in _db.PhStyle on x.StyleID equals st.ID
                                        join s in _db.PhSize on x.SizeID equals s.ID
                                        join c in _db.PhCategorys on x.ColorID equals c.ID
                                        join u in _db.PhUnit on x.UnitID equals u.ID
                                        select new PhProduct()
                                        {
                                            ID = x.ID,
                                            Name = x.Name,
                                            ReOrderLevel = x.ReOrderLevel,
                                            CostPrice = x.CostPrice,
                                            SalePrice = x.SalePrice,
                                            CategoryID = x.CategoryID,
                                            CategoryName = cat.Name,
                                            BrandID = x.BrandID,
                                            BrandName = br.Name,
                                            StyleID = x.StyleID,
                                            StyleName = st.Name,
                                            SizeName = s.Name,
                                            SizeID = x.SizeID,
                                            ColorName = c.Name,
                                            ColorID = x.ColorID,
                                            UnitID = x.UnitID,
                                            UnitName = u.Name,
                                            PhotoByte = x.PhotoByte,
                                            CurrentStock = 0//Convert.ToDecimal(GetProductStock(shopID, Convert.ToInt32(x.ID)))

                                        }).ToList();
            return products;
        }
        public List<PhProduct> GetAllECommerce()
        {
            List<PhProduct> products = _db.PhProducts.ToList();
            return products;
        }

        public List<PhProduct> GetAllByCategorey(int ShopID, int categoryID)
        {
            List<PhProduct> products = _db.PhProducts.Where(c => c.ShopID == ShopID && c.ID == categoryID).ToList();
            return products;
        }

        public dynamic GetProductStock(int shopID, int productID)
        {

            try
            {
                using var _con = _dbAccess.GetConnection();
                var result = _con.Query<dynamic>("SELECT dbo.FNGetProductStock(@ProductID,@ShopID)",
                    new
                    {
                        ProductID = productID,
                        ShopID = shopID
                    },
                    commandType: CommandType.Text);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<string> UploadImages(IFormFile? files, string? productID, string? shopID)
        {
            var response = "";
            if (files == null || files.Length == 0)
            {
                return response;
            }
            string extension = System.IO.Path.GetExtension(files.FileName);
            string fname = new StringBuilder(productID).Append(extension).ToString();
            //var directory = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\{shopID}\\");
            //var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\{shopID}\\", fname.ToLower());

            //var directory = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\{shopID}\\");
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"D:\\Application\\Git\\SMARTBAZAR-ANGULAR\\src\\assets\\img\\ecommerce\\", fname.ToLower());

            //bool exists = Directory.Exists(directory);
            //if (!exists)
            //{
            //    Directory.CreateDirectory(directory);
            //}
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            ////Way - 01
            using var stream = files.OpenReadStream();
            using var image = await SixLabors.ImageSharp.Image.LoadAsync(stream);

            int customWidth = 300;  // Set your desired width
            int customHeight = 300; // Set your desired height

            // Resize the image
            image.Mutate(x => x.Resize(customWidth, customHeight));

            var outputPath = Path.Combine(filePath, files.FileName);
            try
            {
                await image.SaveAsync(filePath);
            }
            catch(Exception ex)
            {

            }

            ////Way - 02
            //using (var stream = new FileStream(filePath, FileMode.Create))
            //{
            //    await files.CopyToAsync(stream);

            //    response = Path.Combine(shopID + "\\" + fname.ToLower());
            //}

            return response;
        }

        public async Task<List<PhProduct>> GetAllProudctList(int shopID, string dropdownType)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<PhProduct>)await _con.QueryAsync<PhProduct>(
                sql: Convert.ToString(StoreProcedure.Name.SP_VSDataListProvider),
                    param: new
                    {
                        Action = dropdownType,
                        ShopID = shopID
                    },
                commandType: CommandType.StoredProcedure);
            return objList ?? new List<PhProduct>();
        }


    }
}
