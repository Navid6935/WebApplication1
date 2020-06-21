using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class Smart_Api_DBContext : DbContext
    {
        public Smart_Api_DBContext()
        {
        }

        public Smart_Api_DBContext(DbContextOptions<Smart_Api_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppDevices> AppDevices { get; set; }
        public virtual DbSet<AppUpdate> AppUpdate { get; set; }
        public virtual DbSet<AppUsers> AppUsers { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<EspSerialActive> EspSerialActive { get; set; }
        public virtual DbSet<Mac> Mac { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<Serial> Serial { get; set; }
        public virtual DbSet<StoredSerials> StoredSerials { get; set; }
        public virtual DbSet<TestTable> TestTable { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppDevices>(entity =>
            {
                entity.HasKey(e => e.DeviceId);

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Imei)
                    .IsRequired()
                    .HasColumnName("imei")
                    .HasMaxLength(200);

                entity.Property(e => e.SaveDate)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Savetime)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Serial)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(10);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Vaziat)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<AppUpdate>(entity =>
            {
                entity.Property(e => e.AppLink)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.AppMode)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<AppUsers>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Day)
                    .IsRequired()
                    .HasColumnName("day")
                    .HasMaxLength(4);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(250);

                entity.Property(e => e.ForgetPassDatetime).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LocationX)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.LocationY)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Mob)
                    .IsRequired()
                    .HasColumnName("mob")
                    .HasMaxLength(200);

                entity.Property(e => e.Mounth)
                    .IsRequired()
                    .HasColumnName("mounth")
                    .HasMaxLength(4);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Savedate)
                    .IsRequired()
                    .HasColumnName("savedate")
                    .HasMaxLength(11);

                entity.Property(e => e.Savetime)
                    .IsRequired()
                    .HasColumnName("savetime")
                    .HasMaxLength(11);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("year")
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.Property(e => e.Category1)
                    .IsRequired()
                    .HasColumnName("Category")
                    .HasMaxLength(30);

                entity.Property(e => e.Serial)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<EspSerialActive>(entity =>
            {
                entity.HasKey(e => e.EsId);

                entity.Property(e => e.Qr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SaveDate)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SaveTime)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Serial)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Mac>(entity =>
            {
                entity.Property(e => e.Mac1)
                    .IsRequired()
                    .HasColumnName("Mac")
                    .HasMaxLength(17);
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.Property(e => e.Accessible)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Serial>(entity =>
            {
                entity.Property(e => e.Qr)
                    .IsRequired()
                    .HasMaxLength(22);

                entity.Property(e => e.Serial1)
                    .IsRequired()
                    .HasColumnName("Serial")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<StoredSerials>(entity =>
            {
                entity.Property(e => e.SaveDate)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SaveTime)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Serial)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Vaziat)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
