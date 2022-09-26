using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayID { get; set; }


        [Required(ErrorMessage = "Açıklama giriniz!")]
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Aciklama { get; set; }



        [Required(ErrorMessage = "Takip Kodu giriniz!")]
        [Column(TypeName = "Varchar")]
        [StringLength(18)]
        public string TakipKodu { get; set; }



        [Required(ErrorMessage = "Personel seçiniz!")]
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Personel { get; set; }



        [Required(ErrorMessage = "Alıcı seçiniz!")]
        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string Alici { get; set; }



        [Required(ErrorMessage = "Tarih seçiniz!")]
        public DateTime Tarih { get; set; }

    }
}