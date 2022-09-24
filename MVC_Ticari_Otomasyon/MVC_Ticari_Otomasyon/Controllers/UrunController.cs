using System;
using System.Collections.Generic;
using MVC_Ticari_Otomasyon.Models.Siniflar;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PagedList;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();

        // GET: Urun
        //public ActionResult UrunlerListesi()
        //{
        //    var urunler = context.Urunler.Where(x=>x.UrunDurumu==true).ToList();        //Ürün Durumu True(Aktif) olanları Listele
        //    return View(urunler);
        //}

        public ActionResult UrunlerListesi(string aranacakKelime, int sayfa = 1)
        {


            var urunler = from x in context.Urunler where x.UrunDurumu == true select x;
            if (!string.IsNullOrEmpty(aranacakKelime))
            {
                urunler = urunler.Where(y => y.UrunAdi.Contains(aranacakKelime)/* || y.UrunMarka.Contains(aranacakKelime)*/);
            }


            return View(urunler.ToList().ToPagedList(sayfa, 10));
        }








        public ActionResult PasifUrunListesi(string aranacakKelime, int sayfa = 1)
        {
            var urunler = from x in context.Urunler where x.UrunDurumu == false select x;
            if (!string.IsNullOrEmpty(aranacakKelime))
            {
                urunler = urunler.Where(y => y.UrunAdi.Contains(aranacakKelime)/* || y.UrunMarka.Contains(aranacakKelime)*/);
            }


            return View(urunler.ToList().ToPagedList(sayfa, 10));




            //var degerler = context.Urunler.Where(x => x.UrunDurumu == false).ToList();
            //return View(degerler);
        }






        public ActionResult UrunuAktifYap(int id)
        {
            var deger = context.Urunler.Find(id);
            deger.UrunDurumu = true;           //Bu satır yerine Personel Class'da Durum için yazılan kodu get-set ederek de yazabiliriz.
            context.SaveChanges();
            return RedirectToAction("UrunlerListesi");
        }





        public ActionResult UrunuPasifYap(int id)
        {
            var deger = context.Urunler.Find(id);
            deger.UrunDurumu = false;           //Bu satır yerine Personel Class'da Durum için yazılan kodu get-set ederek de yazabiliriz.
            context.SaveChanges();
            return RedirectToAction("PasifUrunListesi");
        }








        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in context.Kategoriler.ToList()       //Kategori Listesinden dropdown ile listeleme yapması için Linq                                                                                   sorgusunu yazdım
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAdi,                    //Formda seçilen kategori adını text'e basıcak
                                               Value = x.KategoriID.ToString()          //Text'e basılan Kategorinin ID'sini Value olarak saklayacak.
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UrunEkle(/*[Bind(Include = "UrunID, UrunAdi, UrunMarka, UrunStok, UrunAlisFiyati, UrunSatisFiyati, UrunDurumu, UrunGorseli, Kategoriid, Kategori")] Urun urun, IEnumerable<HttpPostedFileBase> UrunGorseli*/ Urun urun)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                urun.UrunGorseli = "/Images/" + dosyaAdi + uzanti;
            }
            urun.UrunDurumu = true;
            context.Urunler.Add(urun);
            context.SaveChanges();
            return RedirectToAction(nameof(UrunlerListesi));





            //if (ModelState.IsValid)
            //{
            //    foreach (var item in UrunGorseli)
            //    {
            //        if (item.ContentLength > 0)
            //        {
            //            var image = Path.GetFileName(item.FileName);
            //            var path = Path.Combine(Server.MapPath("~/Images"), image);
            //            item.SaveAs(path);
            //            urun.UrunGorseli = "/Images/" + image;
            //            urun.UrunDurumu = true;
            //            context.Urunler.Add(urun);
            //            context.SaveChanges();
            //            return RedirectToAction(nameof(UrunlerListesi));
            //        }
            //        return HttpNotFound();
            //    }
            //}
            //return HttpNotFound();
        }








        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Kategoriler.ToList()       //Kategori Listesinden dropdown ile listeleme yapması için Linq                                                                                   sorgusunu yazdım
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAdi,                    //Formda seçilen kategori adını text'e basıcak
                                               Value = x.KategoriID.ToString()          //Text'e basılan Kategorinin ID'sini Value olarak saklayacak.
                                           }).ToList();
            ViewBag.dgr1 = deger1;


            var deger = context.Urunler.Find(id);
            return View("UrunGuncelle", deger);         //Bu ID'ye sahip olanın bilgileriyle birlikte UrunGuncelle Sayfasını Getir
        }

        [HttpPost]
        public ActionResult UrunGuncelle(/*[Bind(Include = "UrunID, UrunAdi, UrunMarka, UrunStok, UrunAlisFiyati, UrunSatisFiyati, UrunDurumu, UrunGorseli, Kategoriid, Kategori")] Urun urun, IEnumerable<HttpPostedFileBase> UrunGorseli*/ Urun urun)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                urun.UrunGorseli = "/Images/" + dosyaAdi + uzanti;
            }
            var deger = context.Urunler.Find(urun.UrunID);
            deger.UrunAdi = urun.UrunAdi;
            deger.UrunStok = urun.UrunStok;
            deger.UrunAlisFiyati = urun.UrunAlisFiyati;
            deger.UrunSatisFiyati = urun.UrunSatisFiyati;
            deger.UrunGorseli = urun.UrunGorseli;
            deger.UrunMarka = urun.UrunMarka;
            deger.Kategoriid = urun.Kategoriid;
            urun.UrunDurumu = true;
            context.SaveChanges();
            return RedirectToAction("UrunlerListesi");



            //if (ModelState.IsValid)
            //{
            //    foreach (var item in UrunGorseli)
            //    {
            //        if (item.ContentLength > 0)
            //        {
            //            var image = Path.GetFileName(item.FileName);
            //            var path = Path.Combine(Server.MapPath("~/Images"), image);
            //            item.SaveAs(path);
            //            urun.UrunGorseli = "/Images/" + image;

            //            var deger = context.Urunler.Find(urun.UrunID);
            //            deger.UrunAdi = urun.UrunAdi;
            //            deger.UrunStok = urun.UrunStok;
            //            deger.UrunAlisFiyati = urun.UrunAlisFiyati;
            //            deger.UrunSatisFiyati = urun.UrunSatisFiyati;
            //            deger.UrunGorseli = urun.UrunGorseli;
            //            deger.UrunMarka = urun.UrunMarka;
            //            deger.Kategoriid = urun.Kategoriid;
            //            urun.UrunDurumu = true;
            //            context.SaveChanges();
            //            return RedirectToAction("UrunlerListesi");
            //        }
            //        return HttpNotFound();
            //    }
            //}
            //return HttpNotFound();
        }









        [HttpGet]
        public ActionResult UrunleriSil()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UrunleriSil(int id)
        {
            var deger = context.Urunler.Find(id);
            deger.UrunDurumu = false;
            context.SaveChanges();
            return RedirectToAction("UrunlerListesi");
        }












        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            var deger = context.Urunler.Find(id);
            ViewBag.UrunID = deger.UrunID;
            ViewBag.UrunAdi = deger.UrunAdi;
            ViewBag.UrunFiyati = ((double)deger.UrunSatisFiyati);

            List<SelectListItem> deger1 = (from x in context.Urunler.ToList()       //Kategori Listesinden dropdown ile listeleme yapması için Linq                                                                                   sorgusunu yazdım
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAdi,                    //Formda seçilen kategori adını text'e basıcak
                                               Value = x.UrunID.ToString()          //Text'e basılan Kategorinin ID'sini Value olarak saklayacak.
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in context.Cariler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAdi + " " + x.CariSoyadi,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;


            List<SelectListItem> deger3 = (from x in context.Personeller.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAdi + " " + x.PersonelSoyadi,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;

            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket satis)
        {
            satis.SatisHareketTarihi = DateTime.Parse(DateTime.Now.ToShortDateString());
            //var deger = context.SatisHareketleri.Find(satis.SatisHareketID);
            //deger.SatisHareketTarihi = DateTime.Parse(satis.SatisHareketTarihi.ToShortDateString());

            context.SatisHareketleri.Add(satis);
            context.SaveChanges();
            return RedirectToAction("SatisListesi", "Satis");
        }















        [HttpGet]
        public ActionResult FaturaKalemiEkle(int id)
        {
            var deger = context.Urunler.Find(id);
            ViewBag.UrunID = deger.UrunID;


            var faturaID = context.FaturaKalemleri.Where(x => x.Faturaid == id).Select(c => c.Fatura.FaturaID).FirstOrDefault();
            ViewBag.Fatura = faturaID;



            var degerrr = context.Urunler.Find(id);
            ViewBag.Fiyat = ((double)degerrr.UrunSatisFiyati);



            List<SelectListItem> deger1 = (from x in context.Urunler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAdi,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;


            return View();
        }


        [HttpPost]
        public ActionResult FaturaKalemiEkle(FaturaKalem faturaKalem)
        {
            context.FaturaKalemleri.Add(faturaKalem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }




        //public ActionResult UrunListesi()
        //{
        //    var degerler = context.Urunler.Where(x => x.UrunDurumu == true).ToList();
        //    return View(degerler);
        //}




        //public ActionResult UrunuYazdir(int id)                   //Sadece bu Ürünün özelliklerini yazdırmak için bu kod gerekli
        //{
        //    var degerler = context.Urun.Where(x => x.UrunID == id).ToList();
        //    return View(degerler);
        //}



        public ActionResult UrunleriYazdir()
        {
            var degerler = context.Urunler/*.Where(x => x.UrunDurumu == true)*/.ToList();
            return View(degerler);
        }
    }
}