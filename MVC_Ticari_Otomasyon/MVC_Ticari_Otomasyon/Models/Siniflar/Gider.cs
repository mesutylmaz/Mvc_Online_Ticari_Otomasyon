using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int GiderID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string GiderAciklama { get; set; }
        public DateTime GiderTarih { get; set; }
        public decimal GiderTutar { get; set; }
    }
}