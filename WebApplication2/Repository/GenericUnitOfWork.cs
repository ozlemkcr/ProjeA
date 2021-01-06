using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.DAL;

namespace WebApplication2.Repository
{
    public class GenericUnitOfWork:IDisposable
    {
        private eTicaretDbEntities1 DBEntity = new eTicaretDbEntities1();
        public IRepository<Table_entityType> GetRepositoryInstance<Table_entityType>() where Table_entityType : class
        {
            return new GenericRepository<Table_entityType>(DBEntity);
        }
        public void SaveChanges()
        {
            DBEntity.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                    DBEntity.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
    }
}