using System;
using System.Collections.Generic;
using MVC_Ticari_Otomasyon.Models.Siniflar;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MVC_Ticari_Otomasyon.Controllers
{
    [AllowAnonymous]
    public class TanitimController : Controller
    {
        Context context = new Context();


        // GET: Tanitim
        public ActionResult Index()
        {
            return View();
        }





        public ActionResult UrunlerListesi(string aranacakKelime, int sayfa = 1)
        {


            var urunler = from x in context.Urunler where x.UrunDurumu == true select x;
            if (!string.IsNullOrEmpty(aranacakKelime))
            {
                urunler = urunler.Where(y => y.UrunAdi.Contains(aranacakKelime)/* || y.UrunMarka.Contains(aranacakKelime)*/);
            }


            return View(urunler.ToList().ToPagedList(sayfa, 10));
        }






        public ActionResult PersonelListesi(string aranacakKelime, int sayfa = 1)
        {
            var personeller = from x in context.Personeller where x.PersonelDurumu == true select x;
            if (!string.IsNullOrEmpty(aranacakKelime))
            {
                personeller = personeller.Where(y => y.PersonelAdi.Contains(aranacakKelime) || y.PersonelSoyadi.Contains(aranacakKelime));
            }


            return View(personeller.ToList().ToPagedList(sayfa, 10));


            //var degerler = context.Personeller.Where(x => x.PersonelDurumu == true).ToList();
            //return View(degerler);
        }
    }
}