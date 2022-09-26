using System;
using System.Collections.Generic;
using MVC_Ticari_Otomasyon.Models.Siniflar;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Ticari_Otomasyon.Controllers
{
    [AllowAnonymous]        //Global.asax'daki Authorize kısıtını buraya uygulamasın, çünkü buraya herkes erişebilsin istiyoruz.
    public class LoginController : Controller
    {


        Context context = new Context();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }









        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Cari cari)
        {
            cari.CariDurumu = true;
            context.Cariler.Add(cari);
            context.SaveChanges();
            return PartialView();
        }










        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariLogin1(Cari cari)
        {
            var bilgiler = context.Cariler.FirstOrDefault(x => x.CariMaili == cari.CariMaili && x.CariSifresi == cari.CariSifresi);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMaili, false);
                Session["CariMaili"] = bilgiler.CariMaili.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }











        [HttpGet]
        public ActionResult AdminLogin()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var bilgiler = context.Admins.FirstOrDefault(x => x.KullaniciAdi == admin.KullaniciAdi && x.KullaniciSifresi == admin.KullaniciSifresi);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgiler.KullaniciAdi.ToString();
                return RedirectToAction("KategorileriListele", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }












        public ActionResult KVK()
        {
            return View();
        }








        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();      //İstekleri terk et
            return RedirectToAction("Index", "Login");
        }
    }
}