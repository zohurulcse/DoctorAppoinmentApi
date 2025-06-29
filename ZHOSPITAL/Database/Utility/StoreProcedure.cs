namespace ZHOSPITAL.Utility
{
    public class StoreProcedure
    {
        public enum Name
        {
            //SP NAME
            SPDapperTest,
            SP_CREATE_CODE,
            SP_PURCHASE_SAVE,
            SP_PURCHASE_RETURN_SAVE,
            SP_SALE_SAVE_API,
            SP_Sale_RETURN_SAVE,
            SP_CheckRolePermission,
            SP_VSDropDownProvider,
            SP_VSDataListProvider,

            //ZBazar
            SP_ZBDataListProvider,
            SP_ZBDropDownProvider,
            SP_Load_Menus,

            //Function
            FNGetProductStock,

            //Report
            RPT_SPVSPurchaseReport,
            RPT_SPVSPurchaseReturnReport,
            RPT_SPVSSaleReport,
            RPT_SPVSSaleReturnReport,
            RPT_SPVSStockReport,
            RPT_VSSupplierCustomerLedger,

            //Menu
            SP_CmnMenuSetup,
            SP_CmnModuleSetup,
            SP_Load_RolePermissions
        }
    }
}

