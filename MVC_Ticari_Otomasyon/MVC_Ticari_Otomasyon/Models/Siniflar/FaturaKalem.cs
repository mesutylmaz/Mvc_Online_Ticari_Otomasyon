using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }


        [Display(Name = "Ürün Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Ürün adı için en fazla 30 karakter girilebilir!")]
        public string FaturaKalemi { get; set; }



        [Display(Name = "Kalem Miktarı")]
        [Required(ErrorMessage = "Kalem miktarını boş geçemezsiniz!")]
        public int FaturaKalemMiktar { get; set; }



        [Display(Name = "Birim Fiyat")]
        [Required(ErrorMessage = "Birim fiyatı boş geçemezsiniz!")]
        public decimal FaturaKalemBirimFiyat { get; set; }



        [Display(Name = "Kalem Tutarı")]
        [Required(ErrorMessage = "Kalem tutarını boş geçemezsiniz!")]
        public decimal FaturaKalemTutar { get; set; }


        public int Faturaid { get; set; }
        public virtual Fatura Fatura { get; set; }              //1 FaturaKalemi 1 Faturaya olabilir
    }
}