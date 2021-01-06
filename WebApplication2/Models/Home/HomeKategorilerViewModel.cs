using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication2.DAL;
using WebApplication2.Repository;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace WebApplication2.Models.Home
{
    public class HomeKategorilerViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        eTicaretDbEntities1 context = new eTicaretDbEntities1();
        public IPagedList<urunTable> ListOfUrun { get; set; }
        public HomeKategorilerViewModel CreateModel(string search, int pageSize, int? page)
        {
            ////11. video
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@search", search??(object)DBNull.Value)
            };
            IPagedList<urunTable> data = context.Database.SqlQuery<urunTable>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1,pageSize);
            return new HomeKategorilerViewModel()
            {
                ListOfUrun = data
            };


        }
    }
}