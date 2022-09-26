using MVC_Ticari_Otomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }


        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage = "Kategori adı giriniz!")]
        [StringLength(30, ErrorMessage = "Kategori adı için en fazla 30 karakter girilebilir!")]
        [Column(TypeName = "Varchar")]
        public string KategoriAdi { get; set; }




        private bool _ilkDurumDegeri = true;

        
        [Display(Name = "Kategori Durumu")]
        [Column(TypeName = "bit")]
        public bool KategoriDurumu
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



        [Range(1, 250, ErrorMessage = "Kategori kapasitesi en az 1, en fazla 250 olabilir!")]
        [Display(Name = "Kategori Kapasitesi")]
        //[Required(ErrorMessage = "Kategori kapasitesi tanımlayınız!")]
        public int KategoriKapasitesi { get; set; }





        public ICollection<Urun> Uruns { get; set; }        //1 Kategoride 1'den fazla(Çok) Ürün yer alabilir
    }
}
