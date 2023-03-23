using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class UestebanPruebaPasienteContext : DbContext
{
    public UestebanPruebaPasienteContext()
    {
    }

    public UestebanPruebaPasienteContext(DbContextOptions<UestebanPruebaPasienteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pasiente> Pasientes { get; set; }

    public virtual DbSet<TipoSangre> TipoSangres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= UEstebanPruebaPasiente; User ID=sa; TrustServerCertificate=True; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pasiente>(entity =>
        {
            entity.HasKey(e => e.IdPasiente).HasName("PK__Pasiente__78182EAAA4DAAE7B");

            entity.ToTable("Pasiente");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdTipoSangreNavigation).WithMany(p => p.Pasientes)
                .HasForeignKey(d => d.IdTipoSangre)
                .HasConstraintName("FK__Pasiente__IdTipo__1273C1CD");
        });

        modelBuilder.Entity<TipoSangre>(entity =>
        {
            entity.HasKey(e => e.IdTipoSangre).HasName("PK__TipoSang__3FA617D9AE1C2412");

            entity.ToTable("TipoSangre");

            entity.Property(e => e.IdTipoSangre).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
