using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class deviceregisterContext : DbContext
    {
        public deviceregisterContext()
        {
        }

        public deviceregisterContext(DbContextOptions<deviceregisterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdMapping> AdMappings { get; set; } = null!;
        public virtual DbSet<AdsInfo> AdsInfos { get; set; } = null!;
        public virtual DbSet<Adslocation> Adslocations { get; set; } = null!;
        public virtual DbSet<DeviceDetail> DeviceDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=deviceregister;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdMapping>(entity =>
            {
                entity.HasKey(e => e.MappingId)
                    .HasName("PK__AdMappin__8B57819D2C8AA1F8");

                entity.ToTable("AdMapping");

                entity.HasOne(d => d.Ads)
                    .WithMany(p => p.AdMappings)
                    .HasForeignKey(d => d.AdsId)
                    .HasConstraintName("FK__AdMapping__AdsId__29572725");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.AdMappings)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("FK__AdMapping__Devic__2A4B4B5E");
            });

            modelBuilder.Entity<AdsInfo>(entity =>
            {
                entity.HasKey(e => e.AdsId)
                    .HasName("PK__AdsInfo__46AAC63ACA5F4A63");

                entity.ToTable("AdsInfo");

                entity.Property(e => e.AddedOn).HasColumnType("datetime");

                entity.Property(e => e.ExpiredOn).HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.YoutubeUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("YoutubeURL");
            });

            modelBuilder.Entity<Adslocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__Adslocat__30646B6EC5D84028");

                entity.ToTable("Adslocation");

                entity.Property(e => e.LocationId).HasColumnName("locationId");

                entity.Property(e => e.BusinessLocation)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ads)
                    .WithMany(p => p.Adslocations)
                    .HasForeignKey(d => d.AdsId)
                    .HasConstraintName("FK__Adslocati__AdsId__2D27B809");
            });

            modelBuilder.Entity<DeviceDetail>(entity =>
            {
                entity.HasKey(e => e.DeviceId)
                    .HasName("PK__DeviceDe__84BE14D775E85B4D");

                entity.ToTable("DeviceDetail");

                entity.Property(e => e.DeviceId).HasColumnName("deviceId");

                entity.Property(e => e.AddedOn).HasColumnType("date");

                entity.Property(e => e.BusinessLocation)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GenderPrefrence)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mac)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MAC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
