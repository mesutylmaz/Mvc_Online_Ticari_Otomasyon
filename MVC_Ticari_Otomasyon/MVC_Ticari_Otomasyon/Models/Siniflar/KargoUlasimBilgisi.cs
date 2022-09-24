using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class KargoUlasimBilgisi
    {
        [Key]
        public int KargoTakipID { get; set; }



        [Display(Name = "Takip Kodu")]
        [Required(ErrorMessage = "Takip Kodu giriniz!")]
        [Column(TypeName = "Varchar")]
        [StringLength(18)]
        public string KargoTakipKodu { get; set; }



        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Açıklama giriniz!")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; }



        [Display(Name = "Tarih")]
        [Required(ErrorMessage = "Tarih seçiniz!")]
        public DateTime TarihZaman { get; set; }
    }
}
