using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestCrud.models.db.TestCrud;
using TestCrud.models.db.TestCrud.StoreProcedure;
namespace TestCrud.models.db;

public partial class TestCrudContext : DbContext
{
    public TestCrudContext()
    {
    }

    public TestCrudContext(DbContextOptions<TestCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TAlquilerPelicula> TAlquilerPeliculas { get; set; }

    public virtual DbSet<TGenero> TGeneros { get; set; }

    public virtual DbSet<TPelicula> TPeliculas { get; set; }

    public virtual DbSet<TRol> TRols { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    public virtual DbSet<TVentaPelicula> TVentaPeliculas { get; set; }

    // stores procedure 
    public virtual DbSet<SpObtenerPeliculasConStockVentaAlquiler> SpObtenerPeliculasConStockVentaAlquilers {get;set;}
    public virtual DbSet<SpCrud> SpCrud {get;set;}
    public virtual DbSet<SpRecaudadoPorPelicula> SpRecaudadoPorPeliculas {get;set;}
    public virtual DbSet<SpPeliculasAlquiladas> SpPeliculasAlquiladas {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TAlquilerPelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tAlquile__3214EC071F7C1417");

            entity.ToTable("tAlquilerPelicula");

            entity.Property(e => e.CantidadPelicula).HasColumnName("cantidad_pelicula");
            entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");
            entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");
            entity.Property(e => e.FechaDeAlquiler).HasColumnType("datetime");
            entity.Property(e => e.PrecioAlquiler).HasColumnName("precio_alquiler");
            entity.Property(e => e.TotalPagado).HasColumnName("total_pagado");

            entity.HasOne(d => d.CodPeliculaNavigation).WithMany(p => p.TAlquilerPeliculas)
                .HasForeignKey(d => d.CodPelicula)
                .HasConstraintName("FK__tAlquiler__cod_p__30F848ED");

            entity.HasOne(d => d.CodUsuarioNavigation).WithMany(p => p.TAlquilerPeliculas)
                .HasForeignKey(d => d.CodUsuario)
                .HasConstraintName("FK__tAlquiler__cod_u__31EC6D26");
        });

        modelBuilder.Entity<TGenero>(entity =>
        {
            entity.HasKey(e => e.CodGenero).HasName("PK__tGenero__0DACB9D54A450585");

            entity.ToTable("tGenero");

            entity.Property(e => e.CodGenero).HasColumnName("cod_genero");
            entity.Property(e => e.TxtDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("txt_desc");
        });

        modelBuilder.Entity<TPelicula>(entity =>
        {
            entity.HasKey(e => e.CodPelicula).HasName("PK__tPelicul__225F6E085EFDE4D5");

            entity.ToTable("tPelicula");

            entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");
            entity.Property(e => e.CantDisponiblesAlquiler).HasColumnName("cant_disponibles_alquiler");
            entity.Property(e => e.CantDisponiblesVenta).HasColumnName("cant_disponibles_venta");
            entity.Property(e => e.PrecioAlquiler)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precio_alquiler");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precio_venta");
            entity.Property(e => e.TxtDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("txt_desc");

            entity.HasMany(d => d.CodGeneros).WithMany(p => p.CodPeliculas)
                .UsingEntity<Dictionary<string, object>>(
                    "TGeneroPelicula",
                    r => r.HasOne<TGenero>().WithMany()
                        .HasForeignKey("CodGenero")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_pelicula_genero"),
                    l => l.HasOne<TPelicula>().WithMany()
                        .HasForeignKey("CodPelicula")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_genero_pelicula"),
                    j =>
                    {
                        j.HasKey("CodPelicula", "CodGenero").HasName("PK__tGeneroP__6285A5953EFF86E4");
                        j.ToTable("tGeneroPelicula");
                    });
        });

        modelBuilder.Entity<TRol>(entity =>
        {
            entity.HasKey(e => e.CodRol).HasName("PK__tRol__F13B121104D33269");

            entity.ToTable("tRol");

            entity.Property(e => e.CodRol).HasColumnName("cod_rol");
            entity.Property(e => e.SnActivo).HasColumnName("sn_activo");
            entity.Property(e => e.TxtDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("txt_desc");
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.CodUsuario).HasName("PK__tUsers__EA3C9B1A9BB58A97");

            entity.ToTable("tUsers");

            entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");
            entity.Property(e => e.CodRol).HasColumnName("cod_rol");
            entity.Property(e => e.NroDoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nro_doc");
            entity.Property(e => e.SnActivo).HasColumnName("sn_activo");
            entity.Property(e => e.TxtApellido)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("txt_apellido");
            entity.Property(e => e.TxtNombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("txt_nombre");
            entity.Property(e => e.TxtPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("txt_password");
            entity.Property(e => e.TxtUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("txt_user");

            entity.HasOne(d => d.CodRolNavigation).WithMany(p => p.TUsers)
                .HasForeignKey(d => d.CodRol)
                .HasConstraintName("fk_user_rol");
        });

        modelBuilder.Entity<TVentaPelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tVentaPe__3214EC07258F64AE");

            entity.ToTable("tVentaPelicula");

            entity.Property(e => e.CantidadPelicula).HasColumnName("cantidad_pelicula");
            entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");
            entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");
            entity.Property(e => e.FechaDeVenta).HasColumnType("datetime");
            entity.Property(e => e.PrecioVenta).HasColumnName("precio_venta");
            entity.Property(e => e.TotalPagado).HasColumnName("total_pagado");

            entity.HasOne(d => d.CodPeliculaNavigation).WithMany(p => p.TVentaPeliculas)
                .HasForeignKey(d => d.CodPelicula)
                .HasConstraintName("FK__tVentaPel__cod_p__34C8D9D1");

            entity.HasOne(d => d.CodUsuarioNavigation).WithMany(p => p.TVentaPeliculas)
                .HasForeignKey(d => d.CodUsuario)
                .HasConstraintName("FK__tVentaPel__cod_u__35BCFE0A");
        });

        modelBuilder.Entity<SpObtenerPeliculasConStockVentaAlquiler>().HasNoKey();
        modelBuilder.Entity<SpCrud>().HasNoKey();
        modelBuilder.Entity<SpRecaudadoPorPelicula>().HasNoKey();
        modelBuilder.Entity<SpPeliculasAlquiladas>().HasNoKey();
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
