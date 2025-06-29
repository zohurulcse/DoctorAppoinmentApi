namespace ZHOSPITAL.Database.Interface.Authority
{
    public interface ICmnCustomCodeGenerate
    {
        public Task<string> CodeGenerator(string prefix, string table, string columnname, int shopID);
        dynamic PurchaseCodeGenerator(int shopID);
        dynamic SaleCodeGenerator(int shopID);
    }
}
