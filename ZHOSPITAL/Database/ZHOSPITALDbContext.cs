
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Data.Common;
using ZHOSPITAL.Areas.Pharmacy.Models.Account;
using ZHOSPITAL.Areas.Pharmacy.Models.Common;
using ZHOSPITAL.Areas.Pharmacy.Models.CRM;
using ZHOSPITAL.Areas.Pharmacy.Models.HRM;
using ZHOSPITAL.Areas.Pharmacy.Models.Inventory;
using ZHOSPITAL.Areas.Pharmacy.Models.Issue;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Areas.Pharmacy.Models.Sales;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL
{
    public class ZHOSPITALDbContext : DbContext
    {

        #region Constractor
        public ZHOSPITALDbContext(DbContextOptions<ZHOSPITALDbContext> options)
          : base(options)
        {
        }

        #endregion

        #region Common System Admin

        public virtual DbSet<License> License { get; set; }
        public virtual DbSet<Company> Companys { get; set; }
        public virtual DbSet<Branch> Branchs { get; set; }
        public virtual DbSet<ProjectPath> ProjectPaths { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Thana> Thana { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<RegistrationType> RegistrationType { get; set; }
        public virtual DbSet<CmnMaster> CmnMaster { get; set; }
        public virtual DbSet<CmnDetail> CmnDetail { get; set; }
        #endregion

        #region Pharmacy Module

        /// Accounting
        public virtual DbSet<PhReceivePayment> PhReceivePayment { get; set; }

        //Product Setup
        public virtual DbSet<PhCategory> PhCategorys { get; set; }
        public virtual DbSet<PhSubCategory> PhSubCategorys { get; set; }
        public virtual DbSet<PhProduct> PhProducts { get; set; }
        public virtual DbSet<PhBrand> PhBrand { get; set; }
        public virtual DbSet<PhStyle> PhStyle { get; set; }
        public virtual DbSet<PhUnit> PhUnit { get; set; }
        public virtual DbSet<PhSize> PhSize { get; set; }
        public virtual DbSet<PhColor> PhColor { get; set; }

        // CRM
        public virtual DbSet<PhCustomer> PhCustomers { get; set; }

        // HRM
        public virtual DbSet<PhEmployee> PhEmployees { get; set; }
        public virtual DbSet<PhDepartment> PhDepartments { get; set; }
        public virtual DbSet<PhDesignation> PhDesignations { get; set; }

        /// Purchase
        public virtual DbSet<PhPurchaseDetails> PhPurchaseDetails { get; set; }
        public virtual DbSet<PhPurchaseHead> PhPurchaseHeads { get; set; }
        public virtual DbSet<PhPurchaseOrderDetails> PhPurchaseOrderDetails { get; set; }
        public virtual DbSet<PhPurchaseOrderHead> PhPurchaseOrderHead { get; set; }
        public virtual DbSet<PhPurchaseReturnDetails> PhPurchaseReturnDetails { get; set; }
        public virtual DbSet<PhPurchaseReturnHead> PhPurchaseReturnHeads { get; set; }
        public virtual DbSet<PhOpeningStockHead> PhOpeningStockHead { get; set; }
        public virtual DbSet<PhOpeningStockDetails> PhOpeningStockDetails { get; set; }
        public virtual DbSet<PhInventoryHead> PhInventoryHead { get; set; }
        public virtual DbSet<PhInventoryDetails> PhInventoryDetails { get; set; }
        public virtual DbSet<PhIssueHead> PhIssueHead { get; set; }
        public virtual DbSet<PhIssueDetails> PhIssueDetails { get; set; }

        ///Common
        public virtual DbSet<PhSupplier> PhSuppliers { get; set; }
        public virtual DbSet<PhVAT> PhVATs { get; set; }

        //// Sales
        public virtual DbSet<PhSalesHead> PhSalesHeads { get; set; }
        public virtual DbSet<PhSalesDetails> PhSalesDetails { get; set; }
        public virtual DbSet<PhSaleReturnHead> PhSaleReturnHead { get; set; }
        public virtual DbSet<PhSaleReturnDetails> PhSaleReturnDetails { get; set; }
        public virtual DbSet<PhSpecialOffer> PhSpecialOffer { get; set; }
        public virtual DbSet<PhSpecialOfferDetails> PhSpecialOfferDetails { get; set; }

        #endregion

        #region Doctor Appoinment Module   
        public virtual DbSet<DAAssociateType> DAAssociateType { get; set; }
        public virtual DbSet<DADepartment> DADepartment { get; set; }
        public virtual DbSet<DADoctorAppoinment> DADoctorAppoinment { get; set; }
        public virtual DbSet<DADoctorSetup> DADoctorSetup { get; set; }
        public virtual DbSet<DATimeSlotSetup> DATimeSlotSetup { get; set; }
       
        #endregion

        #region Common
        public virtual DbSet<CmnEmailCredential> CmnEmailCredentials { get; set; }
        public virtual DbSet<CmnFTPCredential> CmnFTPCredentials { get; set; }
        public virtual DbSet<CmnSMSUrl> CmnSMSUrls { get; set; }
      
        public virtual DbSet<Bank> Bank { get; set; }
       
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
      

    }
}
