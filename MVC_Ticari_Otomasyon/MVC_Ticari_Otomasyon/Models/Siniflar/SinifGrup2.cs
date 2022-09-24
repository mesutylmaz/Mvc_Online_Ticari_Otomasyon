using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class SinifGrup2
    {
        public string Departman { get; set; }       //Personeller tablosundaki Departmanid sütunundaki veriler int tipinde olduğu için buraya Departman'ı int türünde yazdık
        public int Sayi { get; set; }
    }
}