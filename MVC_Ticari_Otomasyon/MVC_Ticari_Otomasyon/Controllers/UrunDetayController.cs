using System;
using System.Collections.Generic;
using MVC_Ticari_Otomasyon.Models.Siniflar;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context context = new Context();

        // GET: UrunDetay
        public ActionResult Index()
        {
            OrtakVeri ortak = new OrtakVeri();
            //var degerler = context.Urunler.Where(x => x.UrunID == 1).ToList();
            ortak.Deger1 = context.Urunler.Where(x => x.UrunID == 1).ToList();
            ortak.Deger2 = context.Detaylar.Where(x => x.DetayID == 1).ToList();
            return View(ortak);
        }
    }
}