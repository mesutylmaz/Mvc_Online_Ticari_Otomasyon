using QRCoder;      //QRCodeGenerator için
using System;
using System.Collections.Generic;
using System.Drawing;       //Bitmap için
using System.Drawing.Imaging;
using System.IO;        //MemoryStream için
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class QRController : Controller      // QR => Quick Response
    {
        // GET: QR
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(string kod)
        {
            using (MemoryStream ms = new MemoryStream())     //Resim oluşturma gibi dosya akışlarında kullanılır
            {
                QRCodeGenerator kodUret = new QRCodeGenerator();        //QR kod üretmek için kullanılır
                QRCodeGenerator.QRCode karekod = kodUret.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);     //Takip kodunu QR koda çevirerek oluştur

                using (Bitmap resim = karekod.GetGraphic(10))    //QR Kodun çözünürlüğünü gösterir. 10'un altına inerse çözünürlük düşer, üstüne çıkarsa artar.
                {
                    resim.Save(ms, ImageFormat.Png);    //QR kodu Png formatında kaydedicek.
                    ViewBag.karekodimage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}
