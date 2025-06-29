

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ZHOSPITAL.Areas.DoctorAppoinment;
using ZHOSPITAL.Areas.Pharmacy;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Purchase;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Reports;
using ZHOSPITAL.Areas.Pharmacy.Data.Repository.Common;
using ZHOSPITAL.Areas.Pharmacy.Data.Repository.Purchase;
using ZHOSPITAL.Areas.Pharmacy.Data.Repository.Setup;
using ZHOSPITAL.Areas.VarietiesStore;
using ZHOSPITAL.Database;
using ZHOSPITAL.Database.Base;
using ZHOSPITAL.Database.Interface;
using ZHOSPITAL.Database.Interface.Authority;
using ZHOSPITAL.Database.Interface.Common;
using ZHOSPITAL.Database.Interface.Email;
using ZHOSPITAL.Database.Interface.SMS;
using ZHOSPITAL.Database.Repository;
using ZHOSPITAL.Database.Repository.Authority;
using ZHOSPITAL.Database.Repository.Common;
using ZHOSPITAL.Database.Repository.Email;
using ZHOSPITAL.Database.Repository.SMS;
using ZHOSPITAL.Database.Utility;
//using ZHOSPITAL.Database.Utility;

namespace ZHOSPITAL
{
    public class Startup
    {
        #region Declearation

        private readonly IConfiguration _configuartion;
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        #endregion

        #region Contractor
        public Startup(IConfiguration configuartion)
        {
            _configuartion = configuartion;
        }

        #endregion

        #region ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {

            #region Setting Setup
          
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuartion["Jwt:Token"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
 

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
            });

            services.AddHttpClient();

            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            #endregion

            #region Project Interface Dependency Injection Common Module

            //Common
            services.AddSingleton<IConfiguration>(_configuartion);
            services.AddSingleton<IDBAccess, DBAccess>();

            //services.AddTransient<IVSUserRepository, VSUserRepository>();
            //services.AddTransient<IVSUserRoleRepository, VSUserRoleRepository>();
            services.AddTransient<IRegistrationRepository, RegistrationRepository>();
            services.AddTransient<ISystemSecurity, SystemSecurity>();
            services.AddTransient<ILicenseRepository, LicenseRepository>();
            services.AddTransient<IDapperExampleRepository, DapperExampleRepository>();
            //services.AddSingleton<IVSCustomCodeGenerate, VSCustomCodeGenerateRepository>();         
            //services.AddTransient<IVSCustomerRepository, VSCustomerRepository>();
            //services.AddTransient<IVSSupplierRepository, VSSupplierRepository>();
            services.AddSingleton<ICmnEmail, CmnEmailepository>();
            services.AddSingleton<ICmnSMS, CmnSMSRepository>();
            //services.AddSingleton<ICmnDropdownProvider, CmnDropdownProvider>();
            //services.AddTransient<IShopTypeRepository, ShopTypeSetupRepository>();


            //services.AddTransient<IVSDropdownProvider, VSDropdownProvider>();

            //Report
            // services.AddSingleton<IVSReport, VSReportRepository>();

            //Menu
            services.AddSingleton<ICmnMenus, CmnMenusRepository>();
            services.AddSingleton<ICmnMenusPermission, CmnMenusPermissionRepository>();

            #endregion

            #region Project Interface Dependency Injection Pharmacy Module

            services.AddSingleton<IPhCustomCodeGenerate, PhCustomCodeGenerateRepository>();

            services.AddTransient<IPhCustomerRepository, PhCustomerRepository>();
            services.AddTransient<IPhSupplierRepository, PhSupplierRepository>();

            ////Product Setup
            services.AddTransient<IPhCategoryRepository, PhCategoryRepository>();
            services.AddScoped<IPhSubCategoryRepository, PhSubCategoryRepository>();
            services.AddTransient<IPhBrandRepository, PhBrandRepository>();
            services.AddTransient<IPhStyleRepository, PhStyleRepository>();
            services.AddTransient<IPhSizeRepository, PhSizeRepository>();
            services.AddTransient<IPhColorRepository, PhColorRepository>();
            services.AddTransient<IPhUnitRepository, PhUnitRepository>();
            services.AddTransient<IPhProductRepository, PhProductRepository>();

            ////Purchase
            services.AddTransient<IPhPurchaseHeadRepository, PhPurchaseHeadRepository>();
            services.AddTransient<IPhPurchaseDetailsRepository, PhPurchaseDetailsRepository>();
            services.AddTransient<IPhPurchaseReturnHeadRepository, PhPurchaseReturnHeadRepository>();
            services.AddTransient<IPhPurchaseReturnDetailsRepository, PhPurchaseReturnDetailsRepository>();
            //services.AddTransient<IVSPurchaseOrderHeadRepository, VSPurchaseOrderHeadRepository>();

            ////Issue

            ////Sale
            services.AddTransient<IPhSalesHeadRepository, PhSalesHeadRepository>();
            services.AddTransient<IPhSalesDetailsRepository, PhSalesDetailsRepository>();
            services.AddTransient<IPhSaleReturnHeadRepository, PhSaleReturnHeadRepository>();
            services.AddTransient<IPhSaleReturnDetailsRepository, PhSaleReturnDetailsRepository>();

            services.AddTransient<IPhDropdownProvider, PhDropdownProvider>();

            ////Report
            services.AddSingleton<IPhReport, PhReportRepository>();

            #endregion

            #region Project Interface Dependency Injection Doctor Appoinment Module

            services.AddTransient<IDAAssociateTypeRepository, DAAssociateTypeRepository>();
            services.AddTransient<IDADepartmentRepository, DADepartmentRepository>();
            services.AddTransient<IDADoctorAppoinmentRepository, DADoctorAppoinmentRepository>();
            services.AddTransient<IDADoctorSetupRepository, DADoctorSetupRepository>();
            services.AddTransient<IDATimeSlotSetupRepository, DATimeSlotSetupRepository>();

            #endregion

        }

        #endregion

        #region Configure
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
          
            if (app.Environment.IsDevelopment())
            {
                //For swagger open page load
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZHOSPITAL service");
                    c.RoutePrefix = string.Empty;  // Set Swagger UI at apps root
                });


                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


            app.UseHttpsRedirection();

            //app.UseCors(MyAllowSpecificOrigins);


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();
            //app.UseMvc();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();


        }

        #endregion
    }
}
