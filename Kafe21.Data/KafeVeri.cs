using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafe21.Data
{
    public class KafeVeri : DbContext
    {
        public KafeVeri() : base("name=KafeVeri")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SiparisDetay>()//Siparis Detay entitysinin
                .HasRequired(x => x.Urun) // Zorunlu olarak Urun u vardır.
                .WithMany(x => x.SiparisDetaylar)// Ki bu Urun  birden cok siparis Detay' da bulunabilir
                .HasForeignKey(x => x.UrunId)// SiparisDetay'dan Urun'e referans veren FK' sı UrunId alanıdır
                .WillCascadeOnDelete(false);// urun silinirse bağlı olduğu Siparis Detyaı otomatik olarak silme
        }
        public int MasaAdet { get; set; } = 20;
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylar { get; set; }

    }
}
