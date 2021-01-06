using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.Models.Home;

namespace WebApplication2.Controllers
{
    
    public class HomeController : Controller
    {
        eTicaretDbEntities1 ctx = new eTicaretDbEntities1();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Categories(string search, int? page)
        {
            HomeKategorilerViewModel model = new HomeKategorilerViewModel();
            return View(model.CreateModel(search, 2, page));

        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult CheckoutDetay()
        {
            return View();
        }
        public ActionResult MiktarAzalt(int urunid)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var Urun = ctx.urunTables.Find(urunid);
                foreach (var item in cart )
                {
                    int x = item.miktar;
                    if(x >0)
                    {
                        cart.Remove(item);
                        cart.Add(new Item()
                        {
                            urun = Urun,
                            miktar = x
                        });
                    }
                    break;
                }
            }
            return Redirect("Checkout");
        }
        public ActionResult AddtoCart(int urunid )
        {
            if(Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                var Urun = ctx.urunTables.Find(urunid);
                cart.Add(new Item()
                {
                    urun = Urun,
                    miktar = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var Urun = ctx.urunTables.Find(urunid);
                foreach(var item in cart)
                {
                    if(item.urun.urunId == urunid)
                    {
                        int x = item.miktar;
                        cart.Remove(item);
                        cart.Add(new Item()
                        {
                            urun = Urun,
                            miktar = x+1
                        });
                        break;
                    }
                    else
                    {
                        cart.Add(new Item()
                        {
                            urun = Urun,
                            miktar = 1
                        });
                    }
                }
                
                Session["cart"] = cart;
            }
            return Redirect("Categories");
        }
        public ActionResult RemoveFromCart (int urunid)
        {
            List<Item> cart = (List<Item>)Session["cart"];
           // var Urun = ctx.urunTables.Find(urunid);
            foreach(var item in cart)
            {
                if (item.urun.urunId == urunid)
                {
                    cart.Remove(item);
                    break;
                }
            }           
            Session["cart"] = cart;
            return Redirect("Categories");
        }
    }
}