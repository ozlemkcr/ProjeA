using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class KategoriDetay
    {
        public int kategoriId { get; set; }
        [Required(ErrorMessage ="kategori adıgereklidir")]
        [StringLength(100, ErrorMessage ="minimum 3 ve minimum 5ve minimum 100 karakter olmalı", MinimumLength =3)]
        public string kategoriAdi { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDelete { get; set; }
    }
    public class UrunDetay
    {
        public int urunId { get; set; }
        [Required(ErrorMessage ="ürün adı gereklidir")]
        [StringLength(100, ErrorMessage = "minimum 3 ve minimum 5ve minimum 100 karakter olmalı", MinimumLength = 3)]
        public string urunAdi { get; set; }
        [Required]
        [Range(1,50)]
        public Nullable<int> kategoriId { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public Nullable<System.DateTime> eklenmeTarihi { get; set; }
        public Nullable<System.DateTime> degisimTarihi { get; set; }
        [Required(ErrorMessage ="açıklama gereklidir.")]
        public Nullable<System.DateTime> aciklama { get; set; }
        public string urunResmi { get; set; }
        public Nullable<bool> ozellik { get; set; }
        [Required]
        [Range(typeof(int),"1","500",ErrorMessage ="geçersiz nicelik")]
        public Nullable<int> miktar { get; set; }
        [Required]
        [Range(typeof(decimal), "1","200000", ErrorMessage ="geçeriz fiyat")]
        public Nullable<decimal> fiyat { get; set; }
        public SelectList Kategoriler { get; set; }
    }
}