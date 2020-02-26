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
        public DbSet<TipoArchivo> TipoArchivo { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Acreditado> Acreditado { get; set; }
        public DbSet<Credito> Credito { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("MSQL_LIBESCANER"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archivo>(entity =>
            {

                entity.HasOne(d => d.TipoArchivo)
                    .WithMany(p => p.Archivos)
                    .HasForeignKey(d => d.IdTipoArchivo)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Acreditado)
                    .WithMany(p => p.Archivos)
                    .HasForeignKey(d => d.IdAcreditado)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Credito>(entity =>
            {

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Acreditado)
                    .WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.IdAcreditado)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}