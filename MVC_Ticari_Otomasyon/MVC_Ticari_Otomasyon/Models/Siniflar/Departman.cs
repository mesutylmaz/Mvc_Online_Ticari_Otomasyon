using MVC_Ticari_Otomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int DepartmanID { get; set; }


        [Display(Name = "Departman Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Departman adı için en fazla 30 karakter girilebilir!")]
        public string DepartmanAdi { get; set; }



        
        private bool _ilkDurumDegeri = true;


        [Display(Name = "Departman Durumu")]
        [Column(TypeName = "bit")]
        public bool DepartmanDurumu
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

        
        [Display(Name = "Departman Kapasitesi")]
        [Range(1, 250, ErrorMessage = "Departman kapasitesi en az 1, en fazla 250 olabilir!")]
        //[Required(ErrorMessage = "Departman kapasitesi tanımlayınız!")]
        public int DepartmanKapasitesi { get; set; }





        public ICollection<Personel> Personels { get; set; }                 ///1 SatisHareketinin 1'den fazla(Çok) Ürünü olabilir
    }
}