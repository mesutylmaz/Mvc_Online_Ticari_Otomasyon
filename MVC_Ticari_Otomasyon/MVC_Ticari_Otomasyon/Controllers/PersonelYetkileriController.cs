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
    public class PersonelYetkileriController : Controller
    {

        Context context = new Context();

        // GET: PersonelYetkileri
        public ActionResult YetkiListesi(string aranacakKelime, int sayfa = 1)
        {
            var yetkiler = from x in context.PersonelYetkileri where x.PersonelYetkiDurumu == true select x;
            if (!string.IsNullOrEmpty(aranacakKelime))
            {
                yetkiler = yetkiler.Where(y => y.YetkiAdi.Contains(aranacakKelime));
            }


            return View(yetkiler.ToList().ToPagedList(sayfa, 10));


            //var degerler = context.Personeller.Where(x => x.PersonelDurumu == true).ToList();
            //return View(degerler);
        }





        public ActionResult PasifYetkiListesi(string aranacakKelime, int sayfa = 1)
        {
            var yetkiler = from x in context.PersonelYetkileri where x.PersonelYetkiDurumu == false select x;
            if (!string.IsNullOrEmpty(aranacakKelime))
            {
                yetkiler = yetkiler.Where(y => y.YetkiAdi.Contains(aranacakKelime));
            }


            return View(yetkiler.ToList().ToPagedList(sayfa, 10));


            //var degerler = context.Personeller.Where(x => x.PersonelDurumu == false).ToList();
            //return View(degerler);
        }




        public ActionResult YetkiyiAktifYap(int id)
        {
            var deger = context.PersonelYetkileri.Find(id);
            deger.PersonelYetkiDurumu = true;           //Bu satır yerine Personel Class'da Durum için yazılan kodu get-set ederek de yazabiliriz.
            context.SaveChanges();
            return RedirectToAction("YetkiListesi");
        }





        public ActionResult YetkiyiPasifYap(int id)
        {
            var deger = context.PersonelYetkileri.Find(id);
            deger.PersonelYetkiDurumu = false;           //Bu satır yerine Personel Class'da Durum için yazılan kodu get-set ederek de yazabiliriz.
            context.SaveChanges();
            return RedirectToAction("YetkiListesi");
        }





        [HttpGet]
        public ActionResult YetkiEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YetkiEkle(PersonelYetkisi personelYetkisi)
        {
            personelYetkisi.PersonelYetkiDurumu = true;
            context.PersonelYetkileri.Add(personelYetkisi);
            context.SaveChanges();
            return RedirectToAction(nameof(YetkiListesi));
        }






        public ActionResult YetkiGetir(int id)
        {
            var deger = context.PersonelYetkileri.Find(id);
            return View("YetkiGetir", deger);
        }


        public ActionResult YetkiGuncelle(PersonelYetkisi personelYetkisi)
        {
            personelYetkisi.PersonelYetkiDurumu = true;
            var deger = context.PersonelYetkileri.Find(personelYetkisi.YetkiID);
            deger.YetkiAdi = personelYetkisi.YetkiAdi;
            
            context.SaveChanges();
            return RedirectToAction("YetkiListesi");
        }

    }
}