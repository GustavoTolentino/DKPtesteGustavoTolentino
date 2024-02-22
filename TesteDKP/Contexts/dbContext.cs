using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TesteDKP.Domains;

namespace TesteDKP.Contexts
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=TOLEN-PC;Initial Catalog=BancoGustavoTolentinoDKP;User=sa;Pwd=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idade).HasColumnName("idade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Nome)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Valor)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Pedido__idClient__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
