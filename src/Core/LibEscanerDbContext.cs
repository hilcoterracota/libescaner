using libescaner.Model.Catalog;
using libescaner.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace libescaner.Core
{
    public class LibEscanerDbContext : DbContext
    {
        public DbSet<Archivo> Archivo { get; set; }
        public DbSet<TipoArchivo> TipoArchivo { get; set; }

        public LibEscanerDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.2.1;Database=libescaner;User Id=terrask;Password=yPHIwa4men");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archivo>(entity =>
            {
            
                entity.HasOne(d => d.TipoArchivo)
                    .WithMany(p => p.Archivos)
                    .HasForeignKey(d => d.IdTipoArchivo)
                    .OnDelete(DeleteBehavior.ClientSetNull);

 

            });
        }
    }
}