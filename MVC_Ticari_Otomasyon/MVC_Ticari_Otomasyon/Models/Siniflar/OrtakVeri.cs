using MVC_Ticari_Otomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class OrtakVeri
    {
        public IEnumerable<Urun> Deger1 { get; set; }
        public IEnumerable<Detay> Deger2 { get; set; }
    }
}