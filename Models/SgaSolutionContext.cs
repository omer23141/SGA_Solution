using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SGA_Solution.Models;

public partial class SgaSolutionContext : DbContext
{
    public SgaSolutionContext()
    {
    }

    public SgaSolutionContext(DbContextOptions<SgaSolutionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ajuste> Ajustes { get; set; }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Entrada> Entradas { get; set; }

    public virtual DbSet<Merma> Mermas { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Salida> Salidas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-LBTABK9\\SQLEXPRESS;Database=SGA_Solution;Trusted_Connection=SSPI; Encrypt=false; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ajuste>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ajustes__3213E83FF7664411");

            entity.ToTable("ajustes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Caducidad)
                .HasColumnType("date")
                .HasColumnName("caducidad");
            entity.Property(e => e.CantidadS).HasColumnName("cantidadS");
            entity.Property(e => e.CodigoA)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codigoA");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.MovimientoR)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("movimientoR");
            entity.Property(e => e.NombreA)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nombreA");
            entity.Property(e => e.PrecioU)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precioU");
        });

        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__articulo__3213E83F9DE994C4");

            entity.ToTable("articulos");

            entity.HasIndex(e => e.Codigo, "UQ__articulo__40F9A206FAF3B726").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Caducidad)
                .HasColumnType("date")
                .HasColumnName("caducidad");
            entity.Property(e => e.Codigo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioU)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precioU");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<Entrada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__entradas__3213E83FB3633546");

            entity.ToTable("entradas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Caducidad)
                .HasColumnType("date")
                .HasColumnName("caducidad");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodigoA)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codigoA");
            entity.Property(e => e.CostoU)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costoU");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.MovimientoR)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("movimientoR");
            entity.Property(e => e.Proveedor)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("proveedor");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
        });

        modelBuilder.Entity<Merma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__merma__3213E83F69FCDBE8");

            entity.ToTable("merma");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodigoA)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codigoA");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.MovimientoR)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("movimientoR");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__movimien__3213E83F35E9066D");

            entity.ToTable("movimientos");

            entity.HasIndex(e => e.Referencia, "UQ__movimien__85C4EB334B2CAF61").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Referencia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("referencia");
            entity.Property(e => e.Tipo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
        });

        modelBuilder.Entity<Salida>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__salidas__3213E83F9F58B83F");

            entity.ToTable("salidas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Cliente)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("cliente");
            entity.Property(e => e.CodigoA)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codigoA");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.MovimientoR)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("movimientoR");
            entity.Property(e => e.PrecioU)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precioU");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3213E83F7FA82BDC");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Usuario1, "UQ__usuarios__9AFF8FC630FDC245").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApellidoM)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidoM");
            entity.Property(e => e.ApellidoP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidoP");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
