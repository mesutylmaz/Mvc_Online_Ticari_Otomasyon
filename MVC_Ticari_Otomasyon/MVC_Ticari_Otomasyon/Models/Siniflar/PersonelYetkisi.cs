using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class PersonelYetkisi
    {
        [Key]
        public int YetkiID { get; set; }



        [Display(Name = "Yetki")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Yetki adını boş geçemezsiniz!")]
        [StringLength(25, ErrorMessage = "Yetki adı için en fazla 25 karakter girilebilir!")]
        public string YetkiAdi { get; set; }




        private bool _ilkDurumDegeri = true;
        [Display(Name = "Personel Yetki Durumu")]
        [Column(TypeName = "bit")]
        public bool PersonelYetkiDurumu
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
    }
}