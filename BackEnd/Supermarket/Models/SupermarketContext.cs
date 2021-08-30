using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Supermarket.Models
{
    public partial class SupermarketContext : DbContext
    {
        public SupermarketContext()
        {
        }

        public SupermarketContext(DbContextOptions<SupermarketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articoli> Articolis { get; set; }
        public virtual DbSet<CategoriaArticoli> CategoriaArticolis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database = Supermarket; Trusted_Connection = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Articoli>(entity =>
            {
                entity.ToTable("Articoli");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CodiceNumerico).HasColumnName("codice_numerico");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.Prezzo).HasColumnName("prezzo");

                entity.Property(e => e.Scadenza)
                    .HasColumnType("date")
                    .HasColumnName("scadenza");
            });

            modelBuilder.Entity<CategoriaArticoli>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("CategoriaArticoli");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Descrizione).HasColumnName("descrizione");

                entity.Property(e => e.NomeCategoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome_categoria");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
