using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Caso5.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EtapasProduccion> EtapasProduccions { get; set; }

    public virtual DbSet<InspeccionesCalidad> InspeccionesCalidads { get; set; }

    public virtual DbSet<InventarioMateriasPrima> InventarioMateriasPrimas { get; set; }

    public virtual DbSet<InventarioProducto> InventarioProductos { get; set; }

    public virtual DbSet<MateriasPrima> MateriasPrimas { get; set; }

    public virtual DbSet<OrdenesProduccion> OrdenesProduccions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=gestion_produccion;Username=postgres;Password=copito");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EtapasProduccion>(entity =>
        {
            entity.HasKey(e => e.EtapaId).HasName("etapas_produccion_pkey");

            entity.ToTable("etapas_produccion");

            entity.Property(e => e.EtapaId).HasColumnName("etapa_id");
            entity.Property(e => e.CantidadProcesada)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad_procesada");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.NombreEtapa)
                .HasMaxLength(150)
                .HasColumnName("nombre_etapa");
            entity.Property(e => e.OrdenId).HasColumnName("orden_id");

            entity.HasOne(d => d.Orden).WithMany(p => p.EtapasProduccions)
                .HasForeignKey(d => d.OrdenId)
                .HasConstraintName("etapas_produccion_orden_id_fkey");
        });

        modelBuilder.Entity<InspeccionesCalidad>(entity =>
        {
            entity.HasKey(e => e.InspeccionId).HasName("inspecciones_calidad_pkey");

            entity.ToTable("inspecciones_calidad");

            entity.Property(e => e.InspeccionId).HasColumnName("inspeccion_id");
            entity.Property(e => e.EtapaId).HasColumnName("etapa_id");
            entity.Property(e => e.FechaInspeccion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_inspeccion");
            entity.Property(e => e.Inspector)
                .HasMaxLength(150)
                .HasColumnName("inspector");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
            entity.Property(e => e.ProductosDefectuosos)
                .HasPrecision(12, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("productos_defectuosos");
            entity.Property(e => e.Resultado)
                .HasMaxLength(50)
                .HasColumnName("resultado");

            entity.HasOne(d => d.Etapa).WithMany(p => p.InspeccionesCalidads)
                .HasForeignKey(d => d.EtapaId)
                .HasConstraintName("inspecciones_calidad_etapa_id_fkey");
        });

        modelBuilder.Entity<InventarioMateriasPrima>(entity =>
        {
            entity.HasKey(e => e.InventarioId).HasName("inventario_materias_primas_pkey");

            entity.ToTable("inventario_materias_primas");

            entity.Property(e => e.InventarioId).HasColumnName("inventario_id");
            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("cantidad");
            entity.Property(e => e.MateriaId).HasColumnName("materia_id");
            entity.Property(e => e.StockMinimo)
                .HasPrecision(12, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("stock_minimo");

            entity.HasOne(d => d.Materia).WithMany(p => p.InventarioMateriasPrimas)
                .HasForeignKey(d => d.MateriaId)
                .HasConstraintName("inventario_materias_primas_materia_id_fkey");
        });

        modelBuilder.Entity<InventarioProducto>(entity =>
        {
            entity.HasKey(e => e.InventarioId).HasName("inventario_productos_pkey");

            entity.ToTable("inventario_productos");

            entity.Property(e => e.InventarioId).HasColumnName("inventario_id");
            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("cantidad");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.StockMinimo)
                .HasPrecision(12, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("stock_minimo");

            entity.HasOne(d => d.Producto).WithMany(p => p.InventarioProductos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("inventario_productos_producto_id_fkey");
        });

        modelBuilder.Entity<MateriasPrima>(entity =>
        {
            entity.HasKey(e => e.MateriaId).HasName("materias_primas_pkey");

            entity.ToTable("materias_primas");

            entity.Property(e => e.MateriaId).HasColumnName("materia_id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(50)
                .HasColumnName("unidad_medida");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.MateriasPrimas)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("materias_primas_proveedor_id_fkey");
        });

        modelBuilder.Entity<OrdenesProduccion>(entity =>
        {
            entity.HasKey(e => e.OrdenId).HasName("ordenes_produccion_pkey");

            entity.ToTable("ordenes_produccion");

            entity.Property(e => e.OrdenId).HasColumnName("orden_id");
            entity.Property(e => e.CantidadPlaneada)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad_planeada");
            entity.Property(e => e.CantidadReal)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad_real");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Planificada'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaPlanificada).HasColumnName("fecha_planificada");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");

            entity.HasOne(d => d.Producto).WithMany(p => p.OrdenesProduccions)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("ordenes_produccion_producto_id_fkey");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("productos_pkey");

            entity.ToTable("productos");

            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.CostoUnitario)
                .HasPrecision(12, 2)
                .HasColumnName("costo_unitario");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("proveedores_pkey");

            entity.ToTable("proveedores");

            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.Contacto)
                .HasMaxLength(150)
                .HasColumnName("contacto");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Evaluacion)
                .HasPrecision(3, 2)
                .HasColumnName("evaluacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
