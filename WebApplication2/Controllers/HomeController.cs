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
            return View("Index");

        }
        public ActionResult About()
        {
            return View("About");

        }
        public ActionResult Categories(string search, int? page)
        {
            HomeKategorilerViewModel model = new HomeKategorilerViewModel();
            return View(model.CreateModel(search, 8, page));

        }

        public ActionResult categories1()
        {
            return View();

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
            if (Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var Urun = ctx.urunTables.Find(urunid);
                foreach (var item in cart )
                {
                    if(item.urun.urunId == urunid)
                    {
                        int x = item.miktar;
                        if (x > 0)
                        {
                            cart.Remove(item);
                            cart.Add(new Item()
                            {
                                urun = Urun,
                                miktar = x - 1
                            });

                        }
                        break;
                    }                  
                }
            }
            return Redirect("Checkout");
        }
        public ActionResult AddtoCart(int urunid,string url )
        {
                if (Session["cart"] == null)
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
                    var count = cart.Count();
                    var Urun = ctx.urunTables.Find(urunid);
                    
                    for (int i =0;i<count;i++)
                    {
                        if (cart[i].urun.urunId == urunid)
                        {
                            int x = cart[i].miktar;
                            cart.Remove(cart[i]);
                            cart.Add(new Item()
                            {
                                urun = Urun,
                                miktar = x + 1
                            });
                            
                            break;
                        }
                        else
                        {
                            var prd = cart.Where(y => y.urun.urunId == urunid).SingleOrDefault();
                            if(prd == null)
                            {
                                cart.Add(new Item()
                                {
                                    urun = Urun,
                                    miktar = 1
                                });
                            }
                            
                        }
                        
                    }

                    Session["cart"] = cart;
                }
                return Redirect(url);

            
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