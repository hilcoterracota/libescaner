using System;
using libescaner.Model.Breakers;
using libescaner.Model.Catalog;
using libescaner.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace libescaner.Core
{
    public class LibEscanerDbContext : DbContext
    {
        public LibEscanerDbContext()
        { }

        public LibEscanerDbContext(DbContextOptions<LibEscanerDbContext> options) : base(options)
        { }

        public DbSet<Archivo> Archivo { get; set; }

        public DbSet<ArchivoCategoria> ArchivoCategoria { get; set; }

        public DbSet<Categoria> Categoria { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.2.1;Database=libescaner;User Id=terrask;Password=yPHIwa4men");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArchivoCategoria>(entity =>
            {
                entity.HasKey(c => new { c.IdArchivo, c.IdCategoria });

                entity.HasOne(d => d.Archivo)
                    .WithMany(p => p.ArchivoCategorias)
                    .HasForeignKey(d => d.IdArchivo)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.ArchivoCategorias)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

        }
    }
}