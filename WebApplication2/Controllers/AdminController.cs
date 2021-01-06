using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        // GET: Admin
        public List<SelectListItem> GetKategori()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var kat = _unitOfWork.GetRepositoryInstance<kategoriTable>().GetAllRecords();
            foreach (var item in kat)
            {
                list.Add(new SelectListItem { Value = item.kategoriId.ToString(), Text = item.kategoriAdi });

            }
            return list;
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Kategoriler()
        {
            List<kategoriTable> allKategoriler = _unitOfWork.GetRepositoryInstance<kategoriTable>().GetAllRecordsIQueryable().Where(i => i.isDelete == false).ToList();
            return View(allKategoriler);
        }
        public ActionResult AddKategori()
        {
            return UpdateKategori(0);
        }
        public ActionResult UpdateKategori(int kategoriId)
        {
            KategoriDetay kd;
            if (kategoriId != null)
            {
                kd = JsonConvert.DeserializeObject<KategoriDetay>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<kategoriTable>().GetFirstorDefault(kategoriId)));
            }
            else
            {
                kd = new KategoriDetay();
            }
            return View("UpdateKategori", kd);

        }
        public ActionResult kategoriDuzenle(int katid)
        {
            return View(_unitOfWork.GetRepositoryInstance<kategoriTable>().GetFirstorDefault(katid));

        }
        [HttpPost]
        public ActionResult kategoriDuzenle(kategoriTable tbl)
        {
            _unitOfWork.GetRepositoryInstance<kategoriTable>().Update(tbl);
            return RedirectToAction("Kategoriler");

        }
        public ActionResult Urun()
        {
            return View(_unitOfWork.GetRepositoryInstance<urunTable>().GetProduct());

        }
        public ActionResult UrunDuzenle(int urunid)
        {
            ViewBag.kategoriList = GetKategori();
            return View(_unitOfWork.GetRepositoryInstance<urunTable>().GetFirstorDefault(urunid));

        }
        [HttpPost]
        public ActionResult UrunDuzenle(urunTable tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("../UrunImage/"), pic);
                file.SaveAs(path);
            }
            tbl.urunResmi = file != null?pic: tbl.urunResmi;
            tbl.degisimTarihi = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<urunTable>().Update(tbl);
            return RedirectToAction("Urun");

        }
        public ActionResult UrunEkle()
        {
            ViewBag.kategoriList = GetKategori();
            return View();

        }
        [HttpPost]
        public ActionResult UrunEkle(urunTable tbl, HttpPostedFileBase file)
        {
            string pic=null;
            if(file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("../UrunImage/"), pic);
                file.SaveAs(path);
            }
            tbl.urunResmi = pic;
            tbl.eklenmeTarihi = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<urunTable>().Add(tbl);
            return RedirectToAction("Urun");

        }
    }
}