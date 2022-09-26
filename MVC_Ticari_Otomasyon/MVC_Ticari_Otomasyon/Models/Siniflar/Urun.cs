using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }


        
        [Column(TypeName = "varchar")]
        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Ürün adını boş geçemezsiniz!")]
        [StringLength(30, ErrorMessage = "Ürün adı için en fazla 30 karakter girilebilir!")]
        public string UrunAdi { get; set; }



        [Display(Name = "Ürün Markası")]
        [Required(ErrorMessage = "Ürün markası boş geçemezsiniz!")]
        [StringLength(30, ErrorMessage = "Ürün markası için en fazla 30 karakter girilebilir!")]
        public string UrunMarka { get; set; }



        [Display(Name = "Ürün Stoğu")]
        [Required(ErrorMessage = "Ürün stoğu boş geçemezsiniz!")]
        public short UrunStok { get; set; }



        [Display(Name = "Ürün Alış Fiyatı")]
        [Required(ErrorMessage = "Ürün alış fiyatı boş geçemezsiniz!")]
        public decimal UrunAlisFiyati { get; set; }



        [Display(Name = "Ürün Satış Fiyatı")]
        [Required(ErrorMessage = "Ürün satış fiyatını boş geçemezsiniz!")]
        public decimal UrunSatisFiyati { get; set; }



        [Display(Name = "Ürün Durumu")]
        [Column(TypeName = "bit")]
        //[Required(ErrorMessage = "Ürün durumunu boş geçemezsiniz!")]
        public bool UrunDurumu { get; set; }


        [Column(TypeName = "Varchar")]
        [Display(Name = "Ürün Görseli")]
        [Required(ErrorMessage = "Ürün görseli seçiniz!")]
        [StringLength(250, ErrorMessage = "Ürün görseli için en fazla 250 karakter girilebilir!")]
        public string UrunGorseli { get; set; }


        public int Kategoriid { get; set; }           //Bu değişkeni Ürüne istenilen kategoriyi ekleyebilmek için kullanıcaz. Aksi halde, View kısmında kategori ekleme için Kategori.KategoriID denilirse sisteme en son eklenen Kategori'nin KategoriID değerine göre ürüne KategoriID'yi otomatik atıyor.


        public virtual Kategori Kategori { get; set; }                   //1 Ürünün 1 Kategorisi olabilir. Virtual yapmazsam View'da Kategori bilgisini alamam


        public ICollection<SatisHareket> SatisHarekets { get; set; }     //1 Ürünün 1'den fazla(Çok) SatisHareketi olabilir

    }
}