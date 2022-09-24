using MVC_Ticari_Otomasyon.Models.Siniflar;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Alert
        Context context = new Context();


        // GET: Cari
        public ActionResult CariListesi(string aranacakKelime, int sayfa = 1)
        {
            var cariler = from x in context.Cariler where x.CariDurumu == true select x;
            if (!string.IsNullOrEmpty(aranacakKelime))
            {
                cariler = cariler.Where(y => y.CariAdi.Contains(aranacakKelime) || y.CariSoyadi.Contains(aranacakKelime));
            }


            return View(cariler.ToList().ToPagedList(sayfa, 10));



            //var degerler = context.Cariler.Where(x=>x.CariDurumu==true).ToList();
            //return View(degerler);
        }





        public ActionResult PasifCariListesi(string aranacakKelime, int sayfa = 1)
        {
            var cariler = from x in context.Cariler where x.CariDurumu == false select x;
            if (!string.IsNullOrEmpty(aranacakKelime))
            {
                cariler = cariler.Where(y => y.CariAdi.Contains(aranacakKelime) || y.CariSoyadi.Contains(aranacakKelime));
            }


            return View(cariler.ToList().ToPagedList(sayfa, 10));


            //var degerler = context.Cariler.Where(x => x.CariDurumu == false).ToList();
            //return View(degerler);
        }





        public ActionResult CariyiAktifEt(int id)
        {
            var deger = context.Cariler.Find(id);
            deger.CariDurumu = true;
            context.SaveChanges();
            return RedirectToAction("CariListesi");
        }






        [HttpGet]
        public ActionResult CariEkle()
        {
            List<SelectListItem> deger1 = (from x in context.PersonelYetkileri.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.YetkiAdi,
                                               Value = x.YetkiID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;


            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                cari.CariGorseli = "/Images/" + dosyaAdi + uzanti;
            }

            cari.CariDurumu = true;           //Class'da Durum için yazılan kodlar yerine sadece bu satırı da yazabiliriz.
            context.Cariler.Add(cari);
            context.SaveChanges();
            return RedirectToAction("CariListesi");

        }










        public ActionResult CariSil(int id)
        {
            var deger = context.Cariler.Find(id);
            deger.CariDurumu = false;
            context.SaveChanges();
            return RedirectToAction("CariListesi");
        }








        public ActionResult CariGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.PersonelYetkileri.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.YetkiAdi,
                                               Value = x.YetkiID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;



            var deger = context.Cariler.Find(id);
            return View("CariGetir", deger);
        }


        public ActionResult CariGuncelle(Cari cari)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                cari.CariGorseli = "/Images/" + dosyaAdi + uzanti;
            }

            var deger = context.Cariler.Find(cari.CariID);
            deger.CariAdi = cari.CariAdi;
            deger.CariSoyadi = cari.CariSoyadi;
            deger.CariGorseli = cari.CariGorseli;
            deger.CariMaili = cari.CariMaili;
            deger.CariSehir = cari.CariSehir;
            deger.CariMeslek = cari.CariMeslek;
            deger.CariTelefonu = cari.CariTelefonu;
            deger.CariAdresi = cari.CariAdresi;
            deger.Yetki = cari.Yetki;
            context.SaveChanges();
            return RedirectToAction("CariListesi");

        }








        public ActionResult CariSatisGecmisi(int id)
        {
            var degerler = context.SatisHareketleri.Where(x => x.Cariid == id).ToList();
            var cr = context.Cariler.Where(x => x.CariID == id).Select(y => y.CariAdi + " " + y.CariSoyadi).FirstOrDefault();
            ViewBag.Cari = cr;
            return View(degerler);
        }












        //public ActionResult CariyiYazdir(int id)                //Sadece bu Carinin özelliklerini yazdırmak için bu kod gerekli
        //{
        //    var degerler = context.Cariler.Where(x => x.CariID == id).ToList(); ;
        //    return View(degerler);
        //}



        public ActionResult CarileriYazdir()
        {
            var degerler = context.Cariler.ToList();
            return View(degerler);
        }
    }
}