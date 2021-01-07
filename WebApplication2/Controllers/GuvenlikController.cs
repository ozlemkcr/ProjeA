using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using System.Web.Security;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    public class GuvenlikController : Controller
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        eTicaretDbEntities1 db = new eTicaretDbEntities1();
        // GET: Guvenlik
        public ActionResult GirisYap()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Index", "Home", new { user = Session["user"].ToString() });
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult GirisYap(uyeTable t)
        {
            var bilgiler = db.uyeTables.FirstOrDefault(x => x.uyeEmail == t.uyeEmail && x.uyePass == t.uyePass);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.uyeAd, false);
                Session.Add("user", t.uyeEmail);
                Session["rol"] = bilgiler.uyeRol.ToString();
                //foreach ( var x in db.uyeTables.ToList())
                //{
                //    if(x.uyeEmail == t.uyeEmail)
                //    {
                //        Session.Add("rol", x.uyeRol);
                //    }
                //}
                //Session.Add("rol", t.uyeRol);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
        }
        public ActionResult UyeOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeOl(uyeTable tbl)
        {
            tbl.uyelikTarihi = DateTime.Now;
            tbl.uyeRol = "Kullanici";
            _unitOfWork.GetRepositoryInstance<uyeTable>().Add(tbl);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult logout()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Home");       
        }

    }
}