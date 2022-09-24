using MVC_Ticari_Otomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class DinamikFatura
    {
        public IEnumerable<Fatura> deger1 { get; set; }
        public IEnumerable<FaturaKalem> deger2 { get; set; }
    }
}