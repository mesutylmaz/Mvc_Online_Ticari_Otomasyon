using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Alert
        public ActionResult PageError404()
        {
            Response.TrySkipIisCustomErrors = true;     //İstek(Response) => kullanıcı hatasını dene(TrySkipIisCustomErrors)
            return View();
        }





        public ActionResult PageError403()
        {
            Response.TrySkipIisCustomErrors = true;     //İstek(Response) => kullanıcı hatasını dene(TrySkipIisCustomErrors)
            return View();
        }





        public ActionResult PageError401()
        {
            Response.TrySkipIisCustomErrors = true;     //İstek(Response) => kullanıcı hatasını dene(TrySkipIisCustomErrors)
            return View();
        }





        public ActionResult Page401()
        {
            Response.StatusCode = 401;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError401");
        }



        public ActionResult Page403()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError403");
        }



        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError404");
        }
    }
}