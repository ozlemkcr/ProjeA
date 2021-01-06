using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.DAL;

namespace WebApplication2.Models.Home
{
    public class Item
    {
        public urunTable urun { get; set; }
        public int miktar { get; set; }
    }
}