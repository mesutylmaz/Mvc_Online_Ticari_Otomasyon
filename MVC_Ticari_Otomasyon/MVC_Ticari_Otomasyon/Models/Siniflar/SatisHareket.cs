using MVC_Ticari_Otomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisHareketID { get; set; }



        [Display(Name = "Satış Tarihi")]
        public DateTime SatisHareketTarihi { get; set; }



        [Display(Name = "Satış Adedi")]
        public int SatisHareketAdedi { get; set; }



        [Display(Name = "Satış Fiyatı")]
        public decimal SatisHareketFiyati { get; set; }



        [Display(Name = "Toplam Satış Tutarı")]
        public decimal SatisHareketToplamTutari { get; set; }




        public int Urunid { get; set; }
        public virtual Urun Urun { get; set; }                     //1 SatisHareketinin 1 Ürünü olabilir



        public int Cariid { get; set; }
        public virtual Cari Cari { get; set; }                    //1 SatisHareketinin 1 Carisi olabilir



        public int Personelid { get; set; }
        public virtual Personel Personel { get; set; }             //1 SatisHareketinin 1 Personeli olabilir

    }
}