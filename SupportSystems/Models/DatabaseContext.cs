using Microsoft.EntityFrameworkCore;

namespace SupportSystems.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DoUuTien> DoUuTiens { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<YeuCau> YeuCaus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoUuTien>(entity =>
        {
            entity.HasKey(e => e.Madouutien).HasName("PK__DoUuTien__F830DB59234A3AC3");

            entity.ToTable("DoUuTien");

            entity.Property(e => e.Madouutien).HasColumnName("madouutien");
            entity.Property(e => e.Tendouutien)
                .HasMaxLength(50)
                .HasColumnName("tendouutien");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__NhanVien__F3DBC5734AE9001D");

            entity.ToTable("NhanVien");

            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Hinhanh)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("hinhanh");
            entity.Property(e => e.Hoten)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("hoten");
            entity.Property(e => e.Kichhoat).HasColumnName("kichhoat");
            entity.Property(e => e.Ngaysinh).HasColumnName("ngaysinh");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Quyen).HasColumnName("quyen");
        });

        modelBuilder.Entity<YeuCau>(entity =>
        {
            entity.HasKey(e => e.Mayeucau).HasName("PK__YeuCau__F3815ED33F4F0856");

            entity.ToTable("YeuCau");

            entity.Property(e => e.Mayeucau)
                .HasColumnName("mayeucau");
            entity.Property(e => e.Madouutien).HasColumnName("madouutien");
            entity.Property(e => e.ManvGui)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("manv_gui");
            entity.Property(e => e.ManvXuly)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("manv_xuly")
                .IsRequired(false);
            entity.Property(e => e.Ngaygui).HasColumnName("ngaygui");
            entity.Property(e => e.Noidung)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("noidung");
            entity.Property(e => e.Tieude)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tieude");

            entity.HasOne(d => d.MadouutienNavigation).WithMany(p => p.YeuCaus)
                .HasForeignKey(d => d.Madouutien)
                .HasConstraintName("FK__YeuCau__madouuti__0F624AF8");

            entity.HasOne(d => d.ManvGuiNavigation).WithMany(p => p.YeuCauManvGuiNavigations)
                .HasForeignKey(d => d.ManvGui)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__YeuCau__manv_gui__0D7A0286");

            entity.HasOne(d => d.ManvXulyNavigation).WithMany(p => p.YeuCauManvXulyNavigations)
                .HasForeignKey(d => d.ManvXuly)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__YeuCau__manv_xul__0E6E26BF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
