using System;
using System.Collections.Generic;
using System.Linq;

namespace ZHOSPITAL.Database.Base
{
    public interface IBaseRepository<Type> where Type : class
    {
        Task<bool> Add(Type entity);

        Task<Type> Save(Type entity);
        bool Update(Type entity);
        bool Remove(Type entity);
        bool RemoveByCode(string Code);
        bool RemoveById(int Id);
        bool RemoveByLongId(long Id);
        bool RemoveBySmallId(Int16 Id);
        Type GetByCode(string Code);
        Type GetById(int id);
        Type GetById(Int16 id);
        Type GetById(long id);
        List<Type> GetAll();
        string CodeGenerator(string prefix, string table, string columnname);
    }
}
