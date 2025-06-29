
using System.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json.Linq;

namespace ZHOSPITAL.Database.Base
{
    public class BaseRepository<Type> : IBaseRepository<Type> where Type : class
    {
        //public ZHOSPITALDbContext _db = new ZHOSPITALDbContext();
        public readonly ZHOSPITALDbContext _db;

        public BaseRepository(ZHOSPITALDbContext db)
        {
            _db = db;
        }

        public  DbSet<Type> Table
        {
            get { return _db.Set<Type>(); }
        }
        public async Task<bool> Add(Type entity)
        {
            bool result = false;
            try
            {
                //_db.ChangeTracker.Clear();
                await Table.AddAsync(entity);
                result = await _db.SaveChangesAsync() > 0;

               //var id =  _db.Entry(entity).GetDatabaseValues().Properties[0];

               // var id2 = entity.GetType;
               // var ff = entity.GetMember(entity.ToString());

            }
            catch (Exception ex) { }
            return result;
        }

        public async Task<Type> Save(Type entity)
        {
            bool result = false;
            try
            {
                //_db.ChangeTracker.Clear();
                await Table.AddAsync(entity);
                result = await _db.SaveChangesAsync() > 0;

                //var id =  _db.Entry(entity).GetDatabaseValues().Properties[0];

                // var id2 = entity.GetType;
                // var ff = entity.GetMember(entity.ToString());

            }
            catch (Exception ex) { }
            return entity;
        }

        public bool AddRange(IEnumerable<Type> entities)
        {
            bool result = false;
            try
            {
                Table.AddRange(entities);
                result = _db.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                // ignored
            }

            return result;
        }
        //public bool AddorUpdate(Type entity)
        //{
        //    bool result = false;
        //    try
        //    {
        //        Table.AddOrUpdate(entity);
        //        result = _db.SaveChanges() > 0;
        //    }
        //    catch (Exception ex) { }
        //    return result;
        //}
        public bool Update(Type entity)
        {
            bool result = false;
            try
            {
                Table.Attach(entity);
                _db.Entry(entity).State = EntityState.Modified;
                result = _db.SaveChanges() > 0;
            }
            catch (Exception ex) { }
            return result;
        }

        public bool Remove(Type entity)
        {
            bool result = false;
            try
            {
                Table.Remove(entity);
                result = _db.SaveChanges() > 0;
            }
            catch (Exception ex) { }
            return result;
        }
        public bool RemoveByCode(string Code)
        {
            bool result = false;
            try
            {
                Table.Remove(Table.Find(Code));
                result = _db.SaveChanges() > 0;
            }
            catch (Exception ex) { }
            return result;
        }
        public bool RemoveById(int Id)
        {
            bool result = false;
            try
            {
                Table.Remove(Table.Find(Id));
                result = _db.SaveChanges() > 0;
            }
            catch (Exception ex) { }
            return result;
        }

        public bool RemoveByLongId(long Id)
        {
            bool result = false;
            try
            {
                Table.Remove(Table.Find(Id));
                result = _db.SaveChanges() > 0;
            }
            catch (Exception ex) { }
            return result;
        }

        public bool RemoveBySmallId(Int16 Id)
        {
            bool result = false;
            try
            {
                Table.Remove(Table.Find(Id));
                result = _db.SaveChanges() > 0;
            }
            catch (Exception ex) { }
            return result;
        }

        public bool RemoveRange(IEnumerable<Type> entities)
        {
            bool result = false;
            try
            {
                Table.RemoveRange(entities);
                result = _db.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                // ignored
            }

            return result;
        }
        public Type GetByCode(string Code)
        {
            return Table.Find(Code);
        }
        public Type GetById(int id)
        {
            return Table.Find(id);
        }
        public Type GetById(Int16 id)
        {
            return Table.Find(id);
        }
        public Type GetById(long id)
        {
            return Table.Find(id);
        }
        public List<Type> GetAll()
        {
            return Table.ToList();
        }

        public string CodeGenerator(string prefix, string table, string columnname)
        {
            string Code = string.Empty;
            try
            {
                SqlParameter[] sqlParameters ={
                    new SqlParameter
                    {
                        ParameterName = "@PREFIX",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = prefix,
                        Size=15
                    },
                    new SqlParameter
                    {
                        ParameterName = "@TABLE",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = table,
                        Size=150
                    },
                    new SqlParameter
                    {
                        ParameterName = "@COLUMNNAME",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = columnname,
                        Size=6
                    }
                };
                Code = _db.Database.SqlQueryRaw<string>("SP_CREATE_CODE @PREFIX,@TABLE,@COLUMNNAME", sqlParameters).FirstOrDefault();
            }
            catch (Exception ex) { }
            return Code;
        }

        public string GetStatus(string table, string columnname, string Code)
        {
            string Status = string.Empty;
            try
            {
                Status = _db.Database.SqlQuery<string>($"SELECT {columnname} FROM {table} WHERE Code='{Code}'").ToList().FirstOrDefault();
            }
            catch (Exception ex) { }
            return Status;
        }
        public string GetStatus(string table, string columnname, string keycolumn, string Code)
        {
            string Status = string.Empty;
            try
            {
                Status = _db.Database.SqlQuery<string>($"SELECT {columnname} FROM {table} WHERE {keycolumn}='{Code}'").ToList().FirstOrDefault();
            }
            catch (Exception ex) { }
            return Status;
        }
        public string GetProfit()
        {
            //var profit = string.Empty;
            var profit = "0.00";
            try
            {
                //profit = _db.Database.SqlQuery<string>("select sum(s.Payable-pd.CostPrice) as Profit from SalesHead s INNER JOIN SalesDetails sd ON sd.HeadCode = s.Code INNER JOIN PurchaseDetails pd ON pd.ProductCode = sd.ProductCode where s.Date = CONVERT(DATE, GETDATE(), 103)").ToList<string>().FirstOrDefault();
                //profit = _db.Database.SqlQuery<string>("select sum(s.Payable-pd.CostPrice) as Profit from SalesHead s INNER JOIN SalesDetails sd ON sd.HeadCode = s.Code INNER JOIN PurchaseDetails pd ON pd.ProductCode = sd.ProductCode where s.Date = CONVERT(DATE, GETDATE(), 103)").ToList<string>().FirstOrDefault();
                //profit = _db.Database.SqlQuery<string>("SELECT dbo.FNGetProfitToday()").First().ToString();


            }
            catch (Exception ex) { }
            return profit;
        }

        public DataTable ListtoDataTable<T>(List<T> list)
        {
            DataTable dt = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                dt.Columns.Add(prop.Name);
            }
            foreach (T item in list)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }
    }
}
