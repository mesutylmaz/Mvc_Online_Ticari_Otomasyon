using System;
using System.Collections.Generic;
using MVC_Ticari_Otomasyon.Models.Siniflar;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();

        // GET: Istatistik
        public ActionResult Index()
        {
            var deger1 = context.Cariler.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = context.Urunler.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = context.Personeller.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = context.Kategoriler.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = context.Urunler.Sum(x => x.UrunStok).ToString();     //Stok Sayısı
            ViewBag.d5 = deger5;

            var deger6 = (from x in context.Urunler select x.UrunMarka).Distinct().Count().ToString();     //Marka Sayısı
            ViewBag.d6 = deger6;

            var deger7 = context.Urunler.Count(x => x.UrunStok <= 20).ToString();
            ViewBag.d7 = deger7;

            var deger8 = (from x in context.Urunler orderby x.UrunSatisFiyati descending select x.UrunAdi).FirstOrDefault();    //Max Fiyatlı Ürün Adı
            ViewBag.d8 = deger8;

            var deger9 = (from x in context.Urunler orderby x.UrunSatisFiyati ascending select x.UrunAdi).FirstOrDefault();    //Min Fiyatlı Ürün Adı
            ViewBag.d9 = deger9;

            var deger10 = context.Urunler.GroupBy(x => x.UrunMarka).OrderByDescending(x => x.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d10 = deger10;

            var deger11 = context.Urunler.Count(x => x.UrunAdi == "Buzdolabı").ToString();
            ViewBag.d11 = deger11;

            var deger12 = context.Urunler.Count(x => x.UrunAdi == "Laptop").ToString();
            ViewBag.d12 = deger12;

            //var deger13 = (from x in context.SatisHareketleri orderby x.SatisHareketAdedi descending select x.Urun.UrunAdi).Distinct().ToString();
            var deger13 = context.Urunler.Where(u => u.UrunID == (context.SatisHareketleri.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAdi).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = context.SatisHareketleri.Sum(x => x.SatisHareketToplamTutari).ToString();
            ViewBag.d14 = deger14;

            DateTime bugun = DateTime.Today;
            var deger15 = context.SatisHareketleri.Count(x => x.SatisHareketTarihi == bugun).ToString();
            ViewBag.d15 = deger15;

            var deger16 = context.SatisHareketleri.Where(x => x.SatisHareketTarihi == bugun).Sum(x => (decimal?)x.SatisHareketToplamTutari).ToString();  //Bugün kasa tutarı null olursa hata vermemesi için (decimal?) ifadesini yazdık.

            if (deger16 == null || deger16 == "")
            {
                deger16 = "0,00 ₺";
                ViewBag.d16 = deger16;
            }
            else
            {
                ViewBag.d16 = deger16;
            }


            return View();
        }


        public ActionResult KolayTablolar()
        {
            var sorgu = (from x in context.Cariler
                         group x by x.CariSehir into g
                         select new SinifGrup1
                         {
                             Sayi = g.Count(),
                             Sehir = g.Key
                         });
            return View(sorgu.ToList());
        }







        public PartialViewResult Partial1()
        {
            var sorgu2 = (from x in context.Personeller
                          where x.PersonelDurumu == true
                          group x by x.Departman.DepartmanAdi into g
                          select new SinifGrup2
                          {
                              Sayi = g.Count(),
                              Departman = g.Key
                          });
            return PartialView(sorgu2.ToList());
        }





        public PartialViewResult Partial2()
        {
            var cariler = context.Cariler.ToList();
            return PartialView(cariler);
        }




        public PartialViewResult Partial3()
        {
            var sorgu = context.Urunler.ToList();
            return PartialView(sorgu);
        }



        public PartialViewResult Partial4()
        {
            var sorgu2 = (from x in context.Urunler
                          where x.UrunDurumu == true
                          group x by x.UrunMarka into g
                          select new SinifGrup3
                          {
                              Sayi = g.Count(),
                              Marka = g.Key
                          });
            return PartialView(sorgu2.ToList());
        }



        public PartialViewResult Partial5()
        {
            var sorgu2 = (from x in context.Urunler
                          where x.UrunDurumu == true
                          group x by x.Kategori.KategoriAdi into g
                          select new SinifGrup4
                          {
                              Sayi = g.Count(),
                              KategoriAdi = g.Key
                          });
            return PartialView(sorgu2.ToList());
        }
    }
}