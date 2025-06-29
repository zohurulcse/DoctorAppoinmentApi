using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using SixLabors.ImageSharp.Formats.Png;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using ZHOSPITAL.Areas.Pharmacy.Models.Common;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Areas.Pharmacy.ViewModel;
using ZHOSPITAL.Database.Interface.Authority;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Areas.DoctorAppoinment.Controllers.Doctor
{
    [Route("api/[controller]")]
    [ApiController]
    public class DADoctorSetupController : ControllerBase
    {
        #region Dependency Declearation

        private readonly IDADoctorSetupRepository _daDoctorSetupRepository;
        private readonly ISystemSecurity _systemSecurity;
        //private readonly IVSCustomCodeGenerate _vSCustomCodeGenerate;        
        #endregion

        #region Constructor       
        public DADoctorSetupController(IDADoctorSetupRepository daDoctorSetupRepository)//, IVSCustomCodeGenerate vSCustomCodeGenerate
        {
            _daDoctorSetupRepository = daDoctorSetupRepository;
            //_vSCustomCodeGenerate = vSCustomCodeGenerate;
        }

        #endregion

        #region API Controller        
        // GET: api/<CmnRegistrationController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IList<DADoctorSetup> doctorSetup = _daDoctorSetupRepository.GetAllDoctors().ToList();

                //Check List is Not Empty
                if (!doctorSetup.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(doctorSetup);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CmnRegistrationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                DADoctorSetup doctorSetup = await _daDoctorSetupRepository.GetDoctorsByID(id);
                if (doctorSetup != null)
                {
                    return Ok(doctorSetup);
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

        // POST api/<CmnRegistrationController>
        [HttpPost]
        public async Task<IActionResult> Post(DADoctorSetup doctorSetup)
        {
            try
            {
                //ImageHandler imageHandler = new ImageHandler();

                //vSSupplier.CustomCode =await _vSCustomCodeGenerate.CodeGenerator("SUP", "VSuppliers", "Code");
                bool isSaved = await _daDoctorSetupRepository.Add(doctorSetup);
                if (isSaved)
                {
                    return Ok();
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

        // PUT api/<CmnRegistrationController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] DADoctorSetup doctorSetup)
        {
            try
            {
                bool isUpdate = _daDoctorSetupRepository.Update(doctorSetup);
                if (isUpdate)
                {
                    return Ok();
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

        // DELETE api/<CmnRegistrationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                bool isDelete = _daDoctorSetupRepository.RemoveByCode(id);
                if (isDelete)
                {
                    return Ok();
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

        #region Custom API Controller
        [HttpGet("/api/DADoctorSetup/GetDataByID/{id}")]
        public async Task<IActionResult> GetDataByID(int id)
        {
            try
            {
                DADoctorSetup doctorSetup = await _daDoctorSetupRepository.GetDoctorsByID(id);
                if (doctorSetup != null)
                {
                    return Ok(doctorSetup);
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

        [HttpPost("/api/DADoctorSetup/UploadFile/{doctorID}")]
        public async Task<ActionResult<string>> UploadFile(IFormFile profileFile, int doctorID)
        {
            try
            {
                //if (payconfirm != null && entryID > 0)
                //{
                //    var pay = new ConfrimFileModel
                //    {
                //        filePath = payconfirm
                //    };
                //    var _result = await services.ReceivePayConfirmFile(pay, investorCode, entryID, paytype);

                //}

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
                DADoctorSetup doctorSetup =  _daDoctorSetupRepository.GetById(doctorID);                
                doctorSetup.ImageByte = filebyteArr;
                doctorSetup.UpdateDate=DateTime.Now;
                bool isUpdate = _daDoctorSetupRepository.Update(doctorSetup);
                if (isUpdate)
                {
                    return Ok(doctorSetup);
                }
                else
                {
                    return NotFound();
                }

                //Image save to direcotry
                //var file = await _vSProductRepository.UploadImages(profileFile, productID.ToString(), shopID.ToString());
                //return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/DADoctorSetup/GetDataByDepartmentID/{id}")]
        public IActionResult GetDataByDepartmentID(int id)
        {
            try
            {
                IList<DADoctorSetup> doctorSetup = _daDoctorSetupRepository.GetDoctorsByDepartmentID(id);
                if (doctorSetup.Count > 0)
                {
                    return Ok(doctorSetup);
                }
                else
                {
                    return Ok(doctorSetup);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public async Task<string> ReceivePayConfirmFile(ConfrimFileModel m, string investorCode, int entryID, string paytype)
        //{
        //    var fileID = $"InvestorId_{investorCode}_{paytype}_{entryID}";
        //    var file = await fileHandler.UploadFiles(m.filePath, fileID.ToString(), paytype.ToLower());
        //    return file;
        //}


        //public async Task<string> UploadFiles(IFormFile? files, string? fileid, string? type)
        //{
        //    var response = "";
        //    if (files == null || files.Length == 0)
        //    {
        //        return response;
        //    }
        //    if (_dBAccess.GetCompanyShortCode() == "PBIL")
        //    {
        //        var date1 = DateTime.Now.ToString("dd-MMM-yyyy");
        //        var filePathReport = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\{type}\\");
        //        var directory = filePathReport + date1;
        //        var filePath = filePathReport + date1 + "//" + date1 + fileid.ToLower();
        //        bool exists = Directory.Exists(directory);
        //        if (!exists)
        //        {
        //            Directory.CreateDirectory(filePathReport + date1);
        //        }

        //        if (System.IO.File.Exists(filePath))
        //        {
        //            System.IO.File.Delete(filePath);
        //        }
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await files.CopyToAsync(stream);
        //            response = Path.Combine(type + "\\" + date1 + "\\" + fileid.ToLower());
        //        }
        //        return response;
        //    }
        //    else
        //    {
        //        string extension = System.IO.Path.GetExtension(files.FileName);
        //        string fname = new StringBuilder(fileid).Append(extension).ToString();
        //        var directory = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\{type}\\");
        //        var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\{type}\\", fname.ToLower());
        //        bool exists = Directory.Exists(directory);
        //        if (!exists)
        //        {
        //            Directory.CreateDirectory(directory);
        //        }
        //        if (System.IO.File.Exists(filePath))
        //        {
        //            System.IO.File.Delete(filePath);
        //        }
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await files.CopyToAsync(stream);
        //            response = Path.Combine(type + "\\" + fname.ToLower());
        //        }
        //        return response;
        //    }
        //}
        #endregion
    }
}
