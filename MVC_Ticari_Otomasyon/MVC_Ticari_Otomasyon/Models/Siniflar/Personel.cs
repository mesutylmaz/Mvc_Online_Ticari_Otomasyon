using MVC_Ticari_Otomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }



        [Display(Name ="Personel Adı")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Personel adını boş geçemezsiniz!")]
        [StringLength(25, ErrorMessage = "Personel adı için en fazla 25 karakter girilebilir!")]
        public string PersonelAdi { get; set; }



        [Display(Name ="Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Personel soyadını boş geçemezsiniz!")]
        [StringLength(25, ErrorMessage = "Personel soyadı için en fazla 25 karakter girilebilir!")]
        public string PersonelSoyadi { get; set; }



        [Display(Name ="Personel Görseli")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Personel görselini boş geçemezsiniz!")]
        [StringLength(250, ErrorMessage = "Personel görseli en fazla 250 karakter olabilir!")]
        public string PersonelGorseli { get; set; }






        [Display(Name ="Personel Durumu")]
        [Column(TypeName = "bit")]
        //[Required(ErrorMessage = "Personel durumunu seçiniz!")]
        public bool PersonelDurumu { get; set; }



        [Display(Name = "Personel Şehri")]
        [Column(TypeName = "Varchar")]
        //[Required(ErrorMessage = "Personel şehri boş geçemezsiniz!")]
        [StringLength(15, ErrorMessage = "Personel şehri için en fazla 15 karakter girilebilir!")]
        public string PersonelSehir { get; set; }



        [Display(Name = "Personel Maili")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Personel mailini boş geçemezsiniz!")]
        [StringLength(50, ErrorMessage = "Personel maili için en fazla 50 karakter girilebilir!")]
        public string PersonelMaili { get; set; }



        [Display(Name = "Personel Şifresi")]
        [Column(TypeName = "Varchar")]
        //[Required(ErrorMessage = "Personel şifresini boş geçemezsiniz!")]
        [StringLength(20, ErrorMessage = "Personel şifresi için en fazla 20 karakter girilebilir!")]
        public string PersonelSifresi { get; set; }




        [Display(Name = "Üniversite Bilgisi")]
        [Column(TypeName = "Varchar")]
        //[Required(ErrorMessage = "Üniversite adı boş geçemezsiniz!")]
        [StringLength(50, ErrorMessage = "Üniversite adı için en fazla 50 karakter girilebilir!")]
        public string UniversiteBilgisi { get; set; }





        [Display(Name = "Yetenek Bilgisi")]
        [Column(TypeName = "Varchar")]
        //[Required(ErrorMessage = "Personel soyadını boş geçemezsiniz!")]
        [StringLength(100, ErrorMessage = "Yetenek Bilgisi için en fazla 100 karakter girilebilir!")]
        public string YetenekBilgisi { get; set; }




        //[RegularExpression(@"^(05(\d{9}))$", ErrorMessage = "Girilen Telefon Numarası İstenilen Formatta Değildir!")]
        [Display(Name = "Personel Telefonu")]
        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "Personel telefonu için en fazla 20 karakter girilebilir!")]
        public string PersonelTelefonu { get; set; }





        [Display(Name = "Personel Adresi")]
        [Column(TypeName = "Varchar")]
        [StringLength(150, ErrorMessage = "Personel adresi için en fazla 150 karakter girilebilir!")]
        public string PersonelAdresi { get; set; }




        [Column(TypeName = "Char")]
        [StringLength(1)]
        [Required(ErrorMessage = "Personel yetkisi tanımlayınız!")]
        public string Yetki { get; set; }




        public ICollection<SatisHareket> SatisHarekets { get; set; }//1 Personelin 1'den fazla(Çok) SatisHareketi olabilir




        public virtual Departman Departman { get; set; }            //1 Personelin 1 Departmanı olabilir. Virtual yapmazsam View'da Departman bilgisini alamam

        public int Departmanid { get; set; }        //Bu değişkeni Personele istenilen departmanı ekleyebilmek için kullanıcaz. Aksi halde, View kısmında departman ekleme için Departman.DepartmanID denilirse sisteme en son eklenen Departman'ın DepartmanID değerine göre personel DepartmanID'yi otomatik atıyor.
    }
}