using System;
using System.Collections.Generic;
using MVC_Ticari_Otomasyon.Models.Siniflar;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MVC_Ticari_Otomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context context = new Context();
        // GET: Fatura
        public ActionResult Index(string aranacakKelime, int sayfa = 1)
        {
            var faturalar = from x in context.Faturalar select x;
            if (!string.IsNullOrEmpty(aranacakKelime))
            {
                faturalar = faturalar.Where(y => y.FaturaSeriNo.Contains(aranacakKelime) || y.FaturaSiraNo.Contains(aranacakKelime) || y.FaturaVergiDairesi.Contains(aranacakKelime));
            }


            return View(faturalar.ToList().ToPagedList(sayfa, 10));


            //var liste = context.Faturalar.ToList();
            //return View(liste);
        }






        [HttpGet]
        public ActionResult FaturaEkle()
        {
            List<SelectListItem> deger1 = (from x in context.Personeller.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAdi + " " + x.PersonelSoyadi,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;


            List<SelectListItem> deger2 = (from x in context.Cariler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAdi + " " + x.CariSoyadi,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;



            Random rnd = new Random();

            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G" };

            int k1;
            k1 = rnd.Next(0, karakterler.Length);

            int s1;
            s1 = rnd.Next(10000, 100000);

            string seri = karakterler[k1];
            int sira = s1;
            ViewBag.Seri = seri;
            ViewBag.Sira = sira;



            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Fatura fatura)
        {
            context.Faturalar.Add(fatura);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }








        public ActionResult FaturaGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Personeller.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAdi + " " + x.PersonelSoyadi,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;


            List<SelectListItem> deger2 = (from x in context.Cariler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAdi + " " + x.CariSoyadi,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;


            var fatura = context.Faturalar.Find(id);
            return View("FaturaGetir", fatura);
        }








        public ActionResult FaturaGuncelle(Fatura fatura)
        {
            var fat = context.Faturalar.Find(fatura.FaturaID);
            fat.FaturaSeriNo = fatura.FaturaSeriNo;
            fat.FaturaSiraNo = fatura.FaturaSiraNo;
            fat.FaturaTarih = fatura.FaturaTarih;
            fat.FaturaSaat = fatura.FaturaSaat;
            fat.FaturaVergiDairesi = fatura.FaturaVergiDairesi;
            fat.FaturaTeslimAlan = fatura.FaturaTeslimAlan;
            fat.FaturaTeslimEden = fatura.FaturaTeslimEden;
            fat.ToplamTutar = fatura.ToplamTutar;
            context.SaveChanges();
            return RedirectToAction("Index");
        }








        public ActionResult FaturaDetay(int id)
        {
            var seri = context.FaturaKalemleri.Where(x => x.Faturaid == id).Select(c => c.Fatura.FaturaSeriNo).FirstOrDefault();
            var sira = context.FaturaKalemleri.Where(x => x.Faturaid == id).Select(c => c.Fatura.FaturaSiraNo).FirstOrDefault();


            ViewBag.Sira = sira;
            ViewBag.Seri = seri;


            var degerler = context.FaturaKalemleri.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }






        //[HttpGet]
        //public ActionResult FaturaKalemiEkle(int id)
        //{
        //    var faturaID = context.FaturaKalemleri.Where(x=>x.Faturaid==id).Select(c => c.Fatura.FaturaID).FirstOrDefault();
        //    ViewBag.Fatura = faturaID;




        //    List<SelectListItem> deger1 = (from x in context.Urunler.ToList()
        //                                   select new SelectListItem
        //                                   {
        //                                       Text = x.UrunAdi,
        //                                       Value = x.UrunID.ToString()
        //                                   }).ToList();
        //    ViewBag.dgr1 = deger1;


        //    List<SelectListItem> deger2 = (from x in context.Urunler.ToList()
        //                                   select new SelectListItem
        //                                   {
        //                                       Text = x.UrunSatisFiyati.ToString(),
        //                                       Value = x.UrunID.ToString()
        //                                   }).ToList();
        //    ViewBag.dgr2 = deger2;


        //    return View();
        //}


        //[HttpPost]
        //public ActionResult FaturaKalemiEkle(FaturaKalem faturaKalem)
        //{
        //    var fat = context.FaturaKalemleri.Find(faturaKalem.Faturaid);
        //    fat.FaturaKalemAciklama = faturaKalem.FaturaKalemAciklama;
        //    fat.FaturaKalemMiktar = faturaKalem.FaturaKalemMiktar;
        //    fat.FaturaKalemBirimFiyat = faturaKalem.FaturaKalemBirimFiyat;
        //    fat.FaturaKalemTutar = faturaKalem.FaturaKalemBirimFiyat * faturaKalem.FaturaKalemMiktar;
        //    fat.Faturaid = faturaKalem.Faturaid;



        //    context.FaturaKalemleri.Add(fat);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}









        public ActionResult DinamikFaturalar()
        {
            DinamikFatura dinamikFatura = new DinamikFatura();
            dinamikFatura.deger1 = context.Faturalar.ToList();
            dinamikFatura.deger2 = context.FaturaKalemleri.ToList();
            return View(dinamikFatura);
        }



        public ActionResult FaturayiKaydet(string FaturaSeriNo, string FaturaSiraNo, DateTime FaturaTarih, string FaturaVergiDairesi, string FaturaSaat, string FaturaTeslimEden, string FaturaTeslimAlan, string ToplamTutar, FaturaKalem[] kalemler)
        {
            Fatura fatura = new Fatura();
            fatura.FaturaSeriNo = FaturaSeriNo;
            fatura.FaturaSiraNo = FaturaSiraNo;
            fatura.FaturaTarih = FaturaTarih;
            fatura.FaturaVergiDairesi = FaturaVergiDairesi;
            fatura.FaturaSaat = FaturaSaat;
            fatura.FaturaTeslimEden = FaturaTeslimEden;
            fatura.FaturaTeslimAlan = FaturaTeslimAlan;
            fatura.ToplamTutar = decimal.Parse(ToplamTutar);
            context.Faturalar.Add(fatura);

            foreach (var item in kalemler)
            {
                FaturaKalem kalem = new FaturaKalem();
                kalem.FaturaKalemi = item.FaturaKalemi;
                kalem.FaturaKalemBirimFiyat = item.FaturaKalemBirimFiyat;
                kalem.FaturaKalemTutar = item.FaturaKalemTutar;
                kalem.Faturaid = item.Faturaid;
                kalem.FaturaKalemMiktar = item.FaturaKalemMiktar;
                context.FaturaKalemleri.Add(kalem);
            }

            context.SaveChanges();
            return Json("Kayıt işlemi başarılı.", JsonRequestBehavior.AllowGet);
        }








        //public ActionResult FaturayiYazdir(int id)              //Sadece bu Faturanın özelliklerini yazdırmak için bu kod gerekli
        //{
        //    var degerler = context.Faturalar.Where(x => x.FaturaID == id).ToList();
        //    return View(degerler);
        //}



        public ActionResult FaturalariYazdir()
        {
            var degerler = context.Faturalar.ToList();
            return View(degerler);
        }
    }
}