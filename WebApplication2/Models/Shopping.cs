using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ShippingDetay
    {
        public int alisverisDetayId { get; set; }
        [Required]
        public Nullable<int> uyeId { get; set; }
        [Required]
        public string adres { get; set; }
        [Required]
        public string sehir { get; set; }
        [Required]
        public string cadde { get; set; }
        [Required]
        public string ulke { get; set; }
        [Required]
        public string postaKodu { get; set; }
        public Nullable<int> siparisId { get; set; }
        public Nullable<decimal> odenenMiktar { get; set; }
        [Required]
        public string odemeTuru { get; set; }
    }
}