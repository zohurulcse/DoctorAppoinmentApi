namespace ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom
{
    public interface IPhCustomCodeGenerate
    {
        public Task<string> CodeGenerator(string prefix, string table, string columnname, int shopID);
        dynamic PurchaseCodeGenerator(int shopID);
        dynamic SaleCodeGenerator(int shopID);
    }
}
