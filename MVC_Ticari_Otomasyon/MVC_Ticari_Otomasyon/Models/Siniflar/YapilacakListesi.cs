using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class YapilacakListesi
    {
        [Key]
        public int YapilacakID { get; set; }


        [Display(Name = "Başlık")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Baslik { get; set; }


        [Display(Name = "Durum")]
        [Column(TypeName = "bit")]
        public bool Durumu { get; set; }
    }
}
