using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Siniflar
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cari> Cariler { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<Fatura> Faturalar { get; set; }
        public DbSet<FaturaKalem> FaturaKalemleri { get; set; }
        public DbSet<Gider> Giderler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<SatisHareket> SatisHareketleri { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Detay> Detaylar { get; set; }
        public DbSet<YapilacakListesi> YapilacakListeleri { get; set; }
        public DbSet<KargoDetay> KargoDetaylari { get; set; }
        public DbSet<KargoUlasimBilgisi> KargoUlasimBilgileri { get; set; }
        public DbSet<Mesaj> Mesajlar { get; set; }
        public DbSet<PersonelYetkisi> PersonelYetkileri { get; set; }
        
    }
}
