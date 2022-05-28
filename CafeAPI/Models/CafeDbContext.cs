namespace CafeAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CafeDbContext : DbContext
    {
        public CafeDbContext()
            : base("name=CafeDbContext")
        {
        }

        public virtual DbSet<BAIBAO> BAIBAO { get; set; }
        public virtual DbSet<BINHLUAN> BINHLUAN { get; set; }
        public virtual DbSet<CHITIETDONHANG> CHITIETDONHANG { get; set; }
        public virtual DbSet<CHITIETNHAPHANG> CHITIETNHAPHANG { get; set; }
        public virtual DbSet<DONHANG> DONHANG { get; set; }
        public virtual DbSet<HANGSX> HANGSX { get; set; }
        public virtual DbSet<LOAISP> LOAISP { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNG { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAP { get; set; }
        public virtual DbSet<NHAPHANG> NHAPHANG { get; set; }
        public virtual DbSet<PRICE> PRICE { get; set; }
        public virtual DbSet<SANPHAM> SANPHAM { get; set; }
        public virtual DbSet<THONGKE> THONGKE { get; set; }
        public virtual DbSet<TRANGTHAIDH> TRANGTHAIDH { get; set; }
        public virtual DbSet<XUATHANG> XUATHANG { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CHITIETDONHANG>()
            //    .HasMany(e => e.XUATHANG)
            //    .WithOptional(e => e.CHITIETDONHANG)
            //    .HasForeignKey(e => e.CHITIETDH_ID);

            //modelBuilder.Entity<DONHANG>()
            //    .Property(e => e.SDT)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DONHANG>()
            //    .HasMany(e => e.CHITIETDONHANG)
            //    .WithOptional(e => e.DONHANG)
            //    .HasForeignKey(e => e.DONHANG_ID);

            ////modelBuilder.Entity<HANGSX>()
            ////    .HasMany(e => e.LOAISP)
            ////    .WithOptional(e => e.HANGSX)
            ////    .HasForeignKey(e => e.HANGSX_ID);

            ////modelBuilder.Entity<LOAISP>()
            ////    .HasMany(e => e.SANPHAM)
            ////    .WithOptional(e => e.LOAISP)
            ////    .HasForeignKey(e => e.LOAISP_ID);

            //modelBuilder.Entity<NGUOIDUNG>()
            //    .Property(e => e.TENDANGNHAP)
            //    .IsUnicode(false);

            //modelBuilder.Entity<NGUOIDUNG>()
            //    .Property(e => e.SDT)
            //    .IsUnicode(false);

            //modelBuilder.Entity<NGUOIDUNG>()
            //    .HasMany(e => e.BINHLUAN)
            //    .WithOptional(e => e.NGUOIDUNG)
            //    .HasForeignKey(e => e.KHACHHANG_ID);

            //modelBuilder.Entity<NGUOIDUNG>()
            //    .HasMany(e => e.DONHANG)
            //    .WithOptional(e => e.NGUOIDUNG)
            //    .HasForeignKey(e => e.KHACHHANG_ID);

            //modelBuilder.Entity<NHACUNGCAP>()
            //    .Property(e => e.SDT)
            //    .IsUnicode(false);

            //modelBuilder.Entity<NHACUNGCAP>()
            //    .HasMany(e => e.NHAPHANG)
            //    .WithOptional(e => e.NHACUNGCAP)
            //    .HasForeignKey(e => e.NHACC_ID);

            //modelBuilder.Entity<NHAPHANG>()
            //    .HasMany(e => e.CHITIETNHAPHANG)
            //    .WithOptional(e => e.NHAPHANG)
            //    .HasForeignKey(e => e.NHAPHANG_ID);

            //modelBuilder.Entity<NHAPHANG>()
            //    .HasMany(e => e.XUATHANG)
            //    .WithOptional(e => e.NHAPHANG)
            //    .HasForeignKey(e => e.NHAPHANG_ID);

            ////modelBuilder.Entity<SANPHAM>()
            ////    .HasMany(e => e.BAIBAO)
            ////    .WithOptional(e => e.SANPHAM)
            ////    .HasForeignKey(e => e.SANPHAM_ID);

            //modelBuilder.Entity<SANPHAM>()
            //    .HasMany(e => e.BINHLUAN)
            //    .WithOptional(e => e.SANPHAM)
            //    .HasForeignKey(e => e.SANPHAM_ID);

            //modelBuilder.Entity<SANPHAM>()
            //    .HasMany(e => e.CHITIETDONHANG)
            //    .WithOptional(e => e.SANPHAM)
            //    .HasForeignKey(e => e.SANPHAM_ID);

            //modelBuilder.Entity<SANPHAM>()
            //    .HasMany(e => e.CHITIETNHAPHANG)
            //    .WithOptional(e => e.SANPHAM)
            //    .HasForeignKey(e => e.SANPHAM_ID);

            //modelBuilder.Entity<SANPHAM>()
            //    .HasMany(e => e.PRICE)
            //    .WithOptional(e => e.SANPHAM)
            //    .HasForeignKey(e => e.SANPHAM_ID);

            //modelBuilder.Entity<SANPHAM>()
            //    .HasMany(e => e.THONGKE)
            //    .WithOptional(e => e.SANPHAM)
            //    .HasForeignKey(e => e.SANPHAM_ID);

            //modelBuilder.Entity<TRANGTHAIDH>()
            //    .HasMany(e => e.DONHANG)
            //    .WithOptional(e => e.TRANGTHAIDH)
            //    .HasForeignKey(e => e.TRANGTHAI_ID);
        }
    }
}
