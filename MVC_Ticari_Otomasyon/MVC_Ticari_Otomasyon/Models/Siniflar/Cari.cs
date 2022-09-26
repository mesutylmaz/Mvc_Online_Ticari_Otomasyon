using MVC_Ticari_Otomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }


        [Display(Name = "Cari Adı")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Cari adını boş geçemezsiniz!")]
        [StringLength(25, ErrorMessage = "Cari adı için en fazla 25 karakter girilebilir!")]
        public string CariAdi { get; set; }



        [Display(Name = "Cari Soyadı")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Cari soyadını boş geçemezsiniz!")]
        [StringLength(25, ErrorMessage = "Cari soyadı için en fazla 25 karakter girilebilir!")]
        public string CariSoyadi { get; set; }




        [Display(Name = "Cari Görseli")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Cari görselini boş geçemezsiniz!")]
        [StringLength(250, ErrorMessage = "Cari görseli için en fazla 250 karakter girilebilir!")]
        public string CariGorseli { get; set; }




        [Display(Name = "Cari Şehri")]
        [Column(TypeName = "Varchar")]
        [StringLength(15, ErrorMessage = "Cari şehri en fazla 15 karakter girilebilir!")]
        public string CariSehir { get; set; }




        [Display(Name = "Cari Mesleği")]
        [Column(TypeName = "Varchar")]
        [StringLength(25, ErrorMessage = "Cari mesleği en fazla 25 karakter girilebilir!")]
        public string CariMeslek { get; set; }




        [Display(Name = "Cari Maili")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Cari mailini boş geçemezsiniz!")]
        [StringLength(50, ErrorMessage = "Cari maili için en fazla 50 karakter girilebilir!")]
        public string CariMaili { get; set; }



        [Display(Name = "Cari Şifresi")]
        [Column(TypeName = "Varchar")]
        //[Required(ErrorMessage = "Cari şifresini boş geçemezsiniz!")]
        [StringLength(20, ErrorMessage = "Cari şifresi için en fazla 20 karakter girilebilir!")]
        public string CariSifresi { get; set; }



        private bool _ilkDurumDegeri = true;
        [Display(Name = "Cari Durumu")]
        [Column(TypeName = "bit")]
        public bool CariDurumu
        {
            get
            {
                return _ilkDurumDegeri;
            }
            set
            {
                _ilkDurumDegeri = value;
            }
        }





        //[RegularExpression(@"^(05(\d{9}))$", ErrorMessage = "Girilen Telefon Numarası İstenilen Formatta Değildir!")]
        [Display(Name = "Cari Telefonu")]
        [Column(TypeName = "Varchar")]
        [StringLength(11, ErrorMessage = "Cari telefonu için en fazla 11 karakter girilebilir!")]
        public string CariTelefonu { get; set; }





        [Display(Name = "Cari Adresi")]
        [Column(TypeName = "Varchar")]
        [StringLength(150, ErrorMessage = "Cari adresi için en fazla 150 karakter girilebilir!")]
        public string CariAdresi { get; set; }





        [Column(TypeName = "Char")]
        [StringLength(1)]
        [Required(ErrorMessage = "Cari yetkisi tanımlayınız!")]
        public string Yetki { get; set; }



        public ICollection<SatisHareket> SatisHarekets { get; set; }              //1 Carinin 1'den fazla(Çok) SatisHareketi olabilir
    }
}