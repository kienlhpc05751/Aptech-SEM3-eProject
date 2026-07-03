using System;
using System.Collections.Generic;
using GiveAID.Models;
using Microsoft.EntityFrameworkCore;

namespace GiveAID.Data;

public partial class GiveAidContext : DbContext
{
    public GiveAidContext()
    {
    }

    public GiveAidContext(DbContextOptions<GiveAidContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AboutUsSubpage> AboutUsSubpages { get; set; }

    public virtual DbSet<Cause> Causes { get; set; }

    public virtual DbSet<Ngo> Ngos { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Query> Queries { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WelfareProgramme> WelfareProgrammes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=GiveAidDB;User Id=sa;Password=YourPassword123!;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AboutUsSubpage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AboutUsS__3214EC07E5EF5179");

            entity.Property(e => e.MediaUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Cause>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Causes__3214EC0724CC82C0");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Ngo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NGOs__3214EC07C5D66237");

            entity.ToTable("NGOs");

            entity.Property(e => e.ContactInfo).HasMaxLength(500);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Partners__3214EC07E193470C");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.WebsiteLink)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Query>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Queries__3214EC07A199A2B4");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Subject).HasMaxLength(255);

            entity.HasOne(d => d.Member).WithMany(p => p.Queries)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Queries_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0746753322");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534B65E2FB7").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Occupation).HasMaxLength(150);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Member");
        });

        modelBuilder.Entity<WelfareProgramme>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WelfareP__3214EC079B8BB51A");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.MaxDonationAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Cause).WithMany(p => p.WelfareProgrammes)
                .HasForeignKey(d => d.CauseId)
                .HasConstraintName("FK_Programmes_Causes");

            entity.HasOne(d => d.Ngo).WithMany(p => p.WelfareProgrammes)
                .HasForeignKey(d => d.NgoId)
                .HasConstraintName("FK_Programmes_NGOs");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
