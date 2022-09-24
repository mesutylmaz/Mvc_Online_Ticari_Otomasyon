using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class Mesaj
    {
        [Key]
        public int MesajID { get; set; }


        [Display(Name = "Alıcı")]
        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "Alıcı için en fazla 50 karakter girilebilir!")]
        public string Alici { get; set; }



        [Display(Name = "Gönderici")]
        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "Gönderici için en fazla 50 karakter girilebilir!")]
        public string Gonderici { get; set; }



        [Display(Name = "Konu")]
        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "Mesaj konusu için en fazla 50 karakter girilebilir!")]
        public string Konu { get; set; }



        [Display(Name = "İçerik")]
        [Column(TypeName = "Varchar")]
        [StringLength(2000, ErrorMessage = "Mesaj içeriği için en fazla 2000 karakter girilebilir!")]
        public string Icerik { get; set; }




        [Column(TypeName = "Smalldatetime")]
        public DateTime Tarih { get; set; }
    }
}