using System;
using System.Collections.Generic;
using MVC_Ticari_Otomasyon.Models.Siniflar;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        Context context = new Context();

        // GET: Yapilacak
        public ActionResult Index()
        {
            var degerler1 = context.Cariler.Count().ToString();
            ViewBag.D1 = degerler1;

            var degerler2 = (from x in context.Urunler select x.UrunStok).Count();
            var degerler3 = (from x in context.SatisHareketleri select x.SatisHareketAdedi).Count();
            var sonuc = degerler2 / degerler3;
            ViewBag.D2 = sonuc;

            var degerler4 = context.Cariler.Distinct().Count().ToString();
            ViewBag.D3 = degerler4;

            var degerler5 = context.SatisHareketleri.Count().ToString();
            ViewBag.D4 = degerler5;


            var yapilacak = context.YapilacakListeleri.Where(x => x.Durumu == true).ToList();
            return View(yapilacak);
        }








        public ActionResult PasifIndex()
        {
            var degerler1 = context.Cariler.Count().ToString();
            ViewBag.D1 = degerler1;

            var degerler2 = (from x in context.Urunler select x.UrunStok).Count();
            var degerler3 = (from x in context.SatisHareketleri select x.SatisHareketAdedi).Count();
            var sonuc = degerler2 / degerler3;
            ViewBag.D2 = sonuc;

            var degerler4 = context.Cariler.Distinct().Count().ToString();
            ViewBag.D3 = degerler4;

            var degerler5 = context.SatisHareketleri.Count().ToString();
            ViewBag.D4 = degerler5;

            var degerler = context.YapilacakListeleri.Where(x => x.Durumu == false).ToList();
            return View(degerler);
        }





        public ActionResult YapilacakAktifEt(int id)
        {
            var deger = context.YapilacakListeleri.Find(id);
            deger.Durumu = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }









        [HttpGet]
        public ActionResult YapilacakEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YapilacakEkle(YapilacakListesi yapilacakListesi)
        {
            context.YapilacakListeleri.Add(yapilacakListesi);
            yapilacakListesi.Durumu = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }










        [HttpGet]
        public ActionResult YapilacakGuncelle(int id)
        {
            var deger = context.YapilacakListeleri.Find(id);
            return View("YapilacakGuncelle", deger);         //Bu ID'ye sahip olanın bilgileriyle birlikte KategoriGuncelle Sayfasını Getir
        }

        [HttpPost]
        public ActionResult YapilacakGuncelle(YapilacakListesi yapilacakListesi)
        {
            var deger = context.YapilacakListeleri.Find(yapilacakListesi.YapilacakID);
            deger.Baslik = yapilacakListesi.Baslik;

            context.SaveChanges();
            return RedirectToAction("Index");
        }










        public ActionResult YapilacakSil(int id)
        {
            var deger = context.YapilacakListeleri.Find(id);
            deger.Durumu = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}