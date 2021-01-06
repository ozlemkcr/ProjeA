using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebApplication2.Repository
{
    public interface IRepository<Table_entity> where Table_entity:class
    {
        IEnumerable<Table_entity> GetKategori();
        IEnumerable<Table_entity> GetProduct();
        IEnumerable<Table_entity> GetAllRecords();
        IQueryable<Table_entity> GetAllRecordsIQueryable();
        int GetAllRecordCount();
        void Add(Table_entity entitiy);
        void Update(Table_entity entity);
        void UpdateByWhereClause(Expression<Func<Table_entity, bool>> wherePredict, Action<Table_entity> ForEachPredict);
        Table_entity GetFirstorDefault(int recordId);
        void Remove(Table_entity entity);
        void RemovebyWhereClause(Expression<Func<Table_entity, bool>> wherePredict);
        void RemoveRangeByWhereClause(Expression<Func<Table_entity, bool>> wherePredict);
        void InactiveAndDeleteMarkByWhereClause(Expression<Func<Table_entity, bool>> wherePredict, Action<Table_entity> ForEachPredict);
        Table_entity GetFirstorDefaultByParameter(Expression<Func<Table_entity, bool>> wherePredict);
        IEnumerable<Table_entity> GetListParameter(Expression<Func<Table_entity, bool>> wherePredict);
        IEnumerable<Table_entity> GetResultBySqlprocedure(string query, params object[] parameters);
        IEnumerable<Table_entity> GetRecordsToShow(int PageNo, int PageSize, int CurrentPAge, Expression<Func<Table_entity, bool>> wherePredict, Expression<Func<Table_entity, int>> orderByPredict);
    }
}