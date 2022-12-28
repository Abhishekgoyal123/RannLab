using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TradingApp_1.Models
{
    public partial class tradingAppContext : DbContext
    {
        public tradingAppContext()
        {
        }

        public tradingAppContext(DbContextOptions<tradingAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Registeruser> Registerusers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=tradingApp;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registeruser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Register__CB9A1CFFC0268EE9");

                entity.ToTable("Registeruser");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailVerified).HasColumnName("emailVerified");

                entity.Property(e => e.Photo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("photo");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.UserPasword)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
