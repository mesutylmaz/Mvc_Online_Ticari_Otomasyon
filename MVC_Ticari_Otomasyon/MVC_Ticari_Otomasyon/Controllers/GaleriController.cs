using System;
using System.Collections.Generic;
using MVC_Ticari_Otomasyon.Models.Siniflar;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context content = new Context();

        // GET: Image
        public ActionResult Index()
        {
            var degerler = content.Urunler.ToList();
            return View(degerler);
        }
    }
}