using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_ProyectoBDII.Models;

public partial class BibliotecaProyectBdiiContext : DbContext
{
    public BibliotecaProyectBdiiContext()
    {
    }

    public BibliotecaProyectBdiiContext(DbContextOptions<BibliotecaProyectBdiiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Editorial> Editorials { get; set; }

    public virtual DbSet<EstadoPrestamo> EstadoPrestamos { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<TipoPersona> TipoPersonas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__Autor__DD33B031748C91B6");

            entity.ToTable("Autor", "Persona");

            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.NombreAutor)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A101C238F51");

            entity.ToTable("Categoria", "Libro");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.IdEditorial).HasName("PK__Editoria__EF838671F7CB63A5");

            entity.ToTable("Editorial", "Libro");

            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.NombreEditorial)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoPrestamo>(entity =>
        {
            entity.HasKey(e => e.IdEstadoPrestamo).HasName("PK__EstadoPr__BCB87549FD2CFD23");

            entity.ToTable("EstadoPrestamos", "Administrar");

            entity.Property(e => e.IdEstadoPrestamo).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__Libro__3E0B49ADFEC01715");

            entity.ToTable("Libro", "Libro");

            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdAutor)
                .HasConstraintName("FK__Libro__IdAutor__3C69FB99");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Libro__IdCategor__3D5E1FD2");

            entity.HasOne(d => d.IdEditorialNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdEditorial)
                .HasConstraintName("FK__Libro__IdEditori__3E52440B");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__2EC8D2ACC336F8DA");

            entity.ToTable("Persona", "Persona");

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoPersonaNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoPersona)
                .HasConstraintName("FK__Persona__IdTipoP__2C3393D0");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__Prestamo__6FF194C0C36380F9");

            entity.ToTable("Prestamo", "Administrar");

            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.EstadoEntregado)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EstadoRecibido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaConfirmacionDevolucion).HasColumnType("datetime");
            entity.Property(e => e.FechaDevolucion).HasColumnType("datetime");

            entity.HasOne(d => d.IdEstadoPrestamoNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdEstadoPrestamo)
                .HasConstraintName("FK__Prestamo__IdEsta__45F365D3");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__Prestamo__IdLibr__47DBAE45");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__Prestamo__IdPers__46E78A0C");
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.IdUsusario).HasName("PK__Registro__77976505C70A21A8");

            entity.ToTable("Registros", "Administrar");

            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            
        });

        modelBuilder.Entity<TipoPersona>(entity =>
        {
            entity.HasKey(e => e.IdTipoPersona).HasName("PK__Tipo_Per__79FCAFBF452BA356");

            entity.ToTable("Tipo_Persona", "Persona");

            entity.Property(e => e.IdTipoPersona).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
