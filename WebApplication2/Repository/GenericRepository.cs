using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApplication2.DAL;

namespace WebApplication2.Repository
{
    public class GenericRepository<Table_entity> : IRepository<Table_entity> where Table_entity : class
    {
        DbSet<Table_entity> _dbSet;
        private eTicaretDbEntities1 _DBEntity;
        public GenericRepository(eTicaretDbEntities1 DBentity)
        {
            _DBEntity = DBentity;
            _dbSet = DBentity.Set<Table_entity>();
        }
        public IEnumerable<Table_entity> GetKategori()
        {
            return _dbSet.ToList();
        }
        public IEnumerable<Table_entity> GetProduct()
        {
            return _dbSet.ToList();
        }
        public void Add(Table_entity entity)
        {
            _dbSet.Add(entity);
            _DBEntity.SaveChanges();
        }

        public int GetAllRecordCount()
        {
            return _dbSet.Count();
        }

        public IEnumerable<Table_entity> GetAllRecords()
        {
            return _dbSet.ToList();
        }

        public IQueryable<Table_entity> GetAllRecordsIQueryable()
        {
            return _dbSet;
        }

        public Table_entity GetFirstorDefault(int recordId)
        {
            return _dbSet.Find(recordId);
        }

        public Table_entity GetFirstorDefaultByParameter(Expression<Func<Table_entity, bool>> wherePredict)
        {
            return _dbSet.Where(wherePredict).FirstOrDefault();
        }

        public IEnumerable<Table_entity> GetListParameter(Expression<Func<Table_entity, bool>> wherePredict)
        {
            return _dbSet.Where(wherePredict).ToList();
        }

        public IEnumerable<Table_entity> GetRecordsToShow(int PageNo, int PageSize, int CurrentPAge, Expression<Func<Table_entity, bool>> wherePredict, Expression<Func<Table_entity, int>> orderByPredict)
        {
            if(wherePredict!=null)
            {
                return _dbSet.OrderBy(orderByPredict).Where(wherePredict).ToList();

            }
            else
            {
                return _dbSet.OrderBy(orderByPredict).ToList();
            }
        }

        public IEnumerable<Table_entity> GetResultBySqlprocedure(string query, params object[] parameters)
        {
            if(parameters!=null)
            {
                return _DBEntity.Database.SqlQuery<Table_entity>(query, parameters).ToList();
            }
            else
            {
                return _DBEntity.Database.SqlQuery<Table_entity>(query).ToList();
            }
        }

        public void InactiveAndDeleteMarkByWhereClause(Expression<Func<Table_entity, bool>> wherePredict, Action<Table_entity> ForEachPredict)
        {
            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        public void Remove(Table_entity entity)
        {
            if(_DBEntity.Entry(entity).State==EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void RemovebyWhereClause(Expression<Func<Table_entity, bool>> wherePredict)
        {
            Table_entity entity = _dbSet.Where(wherePredict).FirstOrDefault();
            Remove(entity);
        }

        public void RemoveRangeByWhereClause(Expression<Func<Table_entity, bool>> wherePredict)
        {
            List<Table_entity> entity = _dbSet.Where(wherePredict).ToList();
            foreach (var ent in entity)
            {
                Remove(ent);          }
        }

        public void Update(Table_entity entity)
        {
            _dbSet.Attach(entity);
            _DBEntity.Entry(entity).State = EntityState.Modified;
            _DBEntity.SaveChanges();
        }

        public void UpdateByWhereClause(Expression<Func<Table_entity, bool>> wherePredict, Action<Table_entity> ForEachPredict)
        {
            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }
    }
}