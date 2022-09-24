using MVC_Ticari_Otomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class Fatura
    {
        [Key]
        public int FaturaID { get; set; }



        [Display(Name = "Fatura Seri No")]
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }



        [Display(Name = "Fatura Sıra No")]
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSiraNo { get; set; }



        [Display(Name = "Fatura Tarihi")]
        [Required(ErrorMessage = "Fatura tarihini boş geçemezsiniz!")]
        public DateTime FaturaTarih { get; set; }




        [Display(Name = "Fatura Saati")]
        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string FaturaSaat { get; set; }



        [Display(Name = "Teslim Eden")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Teslim eden bilgisi boş geçilemez!")]
        public string FaturaTeslimEden { get; set; }



        [Display(Name = "Teslim Alan")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Teslim alan bilgisi boş geçilemez!")]
        public string FaturaTeslimAlan { get; set; }



        [Display(Name = "Vergi Dairesi")]
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string FaturaVergiDairesi { get; set; }



        [Display(Name = "Toplam Tutar")]
        public decimal ToplamTutar { get; set; }


        public ICollection<FaturaKalem> FaturaKalems { get; set; }           //1 Faturanın 1'den fazla(Çok) FaturaKalemi olabilir

    }
}