using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Collections;
using System.Net;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Database.Interface.Authority;
using ZHOSPITAL.Models.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Areas.Pharmacy.Controllers.Product_Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhProductController : ControllerBase
    {
        #region Declearation
        private readonly IPhProductRepository _phProductRepository;
        private readonly ISystemSecurity _systemSecurity;
        private readonly IPhCustomCodeGenerate _phCustomCodeGenerate;
        private readonly IPhDropdownProvider _phDropdownProvider;
        #endregion

        #region Constractor
        public PhProductController(IPhProductRepository phProductRepository, IPhCustomCodeGenerate phCustomCodeGenerate, 
            IPhDropdownProvider vSDropdownProvider)
        {
            _phProductRepository = phProductRepository;
            _phCustomCodeGenerate = phCustomCodeGenerate;
            _phDropdownProvider = vSDropdownProvider;
        }
        #endregion

        #region Api Action

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IList<PhProduct> products = _phProductRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!products.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(products);
                }

            }
            catch
            {
                //Send Bad Request Status
                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                PhProduct product = _phProductRepository.GetById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PhProduct product)// [FromBody] 
        {
            try
            {
                product = await _phProductRepository.Save(product);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }

        }


        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] PhProduct product)
        {
            try
            {
                bool isUpdate = _phProductRepository.Update(product);
                if (isUpdate)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                bool isDelete = _phProductRepository.RemoveByLongId(id);
                if (isDelete)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion

        #region Custom Api Action
        [HttpGet("/api/PhProduct/GetAllProudctList/{shopID}/{listType}")]
        public async Task<IActionResult> GetAllProudctList(int shopID,string listType)
        {
            try
            {
                IList<PhProduct> products = await _phProductRepository.GetAllProudctList(shopID, listType);

                //Check List is Not Empty
                if (!products.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(products);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }       

        [HttpGet("/api/PhProduct/Approve/{productID}")]
        public IActionResult Approve(long productID)
        {
            try
            {
                PhProduct product = new PhProduct();
                product = _phProductRepository.GetById(productID);
                product.ApproveStatus = "Approved";
                bool isUpdate = _phProductRepository.Update(product);
                if (isUpdate)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("/api/PhProduct/uploadFile/{productID}/{shopID}")]
        public async Task<IActionResult> uploadFile(int productID,int shopID,IFormFile profileFile)//,IFormFile profileFile , IFormFile profileFile
        {
            try
            {
                //Image save byte to database
                byte[] filebyteArr = new byte[0];

                //02 Way

                using (var stream = profileFile.OpenReadStream())
                {
                    using (var image = await Image.LoadAsync(stream))
                    {
                        image.Mutate(x => x.Resize(300, 300)); // Resize to 100x100

                        using (var ms = new MemoryStream())
                        {
                            await image.SaveAsync(ms, new PngEncoder());
                            filebyteArr = ms.ToArray();
                            //return File(resizedImageBytes, "image/png");
                        }
                    }
                }

                // 02 Way End

                //using (var memoryStream = new MemoryStream())
                //{
                //    profileFile.OpenReadStream().CopyTo(memoryStream);                   
                //    filebyteArr = memoryStream.ToArray();
                //    // use filebyteArr for saving in database
                //}
                PhProduct product = _phProductRepository.GetById(Convert.ToInt64(productID));
                product.PhotoByte = filebyteArr;
                bool isUpdate = _phProductRepository.Update(product);
                if (isUpdate)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound();
                }

                //Image save to direcotry
                //var file = await _vSProductRepository.UploadImages(profileFile, productID.ToString(), shopID.ToString());
                //return Ok();

            }
            catch
            {
                return BadRequest();
            }
            //return Ok("");
        }

        [HttpGet("/api/PhProduct/GetProductStock/{shopID}/{productID}")]
        public IActionResult GetProductStock(int shopID, int productID)
        {
            try
            {
                var productStock = _phProductRepository.GetProductStock(shopID, productID);

                var dd = productStock[0];
                //Check List is Not Empty
                if (productStock != null)
                {
                    return Ok(productStock[0]);
                    //If List is Empty Then Send NotFound Status
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

    }
}
