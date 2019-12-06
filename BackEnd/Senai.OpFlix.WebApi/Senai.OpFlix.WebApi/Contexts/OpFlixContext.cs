using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Lancamentos> Lancamentos { get; set; }
        public virtual DbSet<PlataformasMidias> PlataformasMidias { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Favoritos> Favoritos { get; set; }

        // Unable to generate entity type for table 'dbo.OndeLanca'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=M_OpFlix;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.HasIndex(e => e.Categoria)
                    .HasName("UQ__Categori__08015F8BAA9C33C7")
                    .IsUnique();

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lancamentos>(entity =>
            {
                entity.HasKey(e => e.IdLancamento);

                entity.HasIndex(e => e.Titulo)
                    .HasName("UQ__Lancamen__7B406B56481CFCCF")
                    .IsUnique();

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.FilmeSerie)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse).HasColumnType("text");

                entity.Property(e => e.TempoDuracao)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Lancament__IdCat__5441852A");
            });

            modelBuilder.Entity<PlataformasMidias>(entity =>
            {
                entity.HasKey(e => e.IdPlataformaMidia);

                entity.HasIndex(e => e.PlataformaMidia)
                    .HasName("UQ__Platafor__AA38897D59F1BD82")
                    .IsUnique();

                entity.Property(e => e.PlataformaMidia)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D10534B2CC8341")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Usuarios__7D8FE3B2ECEA35F4")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Permissao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Favoritos>().HasKey(p => new { p.IdUsuario, p.IdLancamento });

            modelBuilder.Entity<Favoritos>()
            .HasOne<Usuarios>(sc => sc.Usuario)
            .WithMany(s => s.Favoritos)
            .HasForeignKey(sc => sc.IdUsuario);

            modelBuilder.Entity<Favoritos>()
            .HasOne<Lancamentos>(sc => sc.Lancamento)
            .WithMany(s => s.Favoritos)
            .HasForeignKey(sc => sc.IdLancamento);

        }
    }
}
