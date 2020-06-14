namespace SellCamera.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SellCameraDataModel : DbContext
    {
        public SellCameraDataModel()
            : base("name=SellCameraDataModel")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BaoHanh> BaoHanhs { get; set; }
        public virtual DbSet<Binhluan> Binhluans { get; set; }
        public virtual DbSet<ChitietDH> ChitietDHs { get; set; }
        public virtual DbSet<DonhangKH> DonhangKHs { get; set; }
        public virtual DbSet<HangSX> HangSXes { get; set; }
        public virtual DbSet<Hopdong> Hopdongs { get; set; }
        public virtual DbSet<Khuyenmai> Khuyenmais { get; set; }
        public virtual DbSet<LoaiSP> LoaiSPs { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<SPkhuyenmai> SPkhuyenmais { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Thongsokythuat> Thongsokythuats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Phonenumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Avatar)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Binhluans)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.MaKH);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.DonhangKHs)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.MaKH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChitietDH>()
                .HasMany(e => e.BaoHanhs)
                .WithOptional(e => e.ChitietDH)
                .HasForeignKey(e => e.MaSp);

            modelBuilder.Entity<HangSX>()
                .Property(e => e.tenhang)
                .IsFixedLength();

            modelBuilder.Entity<HangSX>()
                .HasMany(e => e.Sanphams)
                .WithRequired(e => e.HangSX1)
                .HasForeignKey(e => e.HangSX)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Khuyenmai>()
                .HasMany(e => e.SPkhuyenmais)
                .WithRequired(e => e.Khuyenmai)
                .HasForeignKey(e => e.MaSPKM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiSP>()
                .HasMany(e => e.Sanphams)
                .WithRequired(e => e.LoaiSP1)
                .HasForeignKey(e => e.LoaiSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nhacungcap>()
                .Property(e => e.phonenumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Nhacungcap>()
                .HasMany(e => e.Hopdongs)
                .WithRequired(e => e.Nhacungcap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sanpham>()
                .HasMany(e => e.Binhluans)
                .WithRequired(e => e.Sanpham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sanpham>()
                .HasMany(e => e.Hopdongs)
                .WithRequired(e => e.Sanpham)
                .HasForeignKey(e => e.IDSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sanpham>()
                .HasMany(e => e.SPkhuyenmais)
                .WithRequired(e => e.Sanpham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sanpham>()
                .HasMany(e => e.Thongsokythuats)
                .WithRequired(e => e.Sanpham)
                .WillCascadeOnDelete(false);
        }
    }
}
