using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Biblioteca_ProyectoBDII.Models
{
    public partial class BibliotecaProyect_BDIIContext : DbContext
    {
        public BibliotecaProyect_BDIIContext()
        {
        }

        public BibliotecaProyect_BDIIContext(DbContextOptions<BibliotecaProyect_BDIIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; } = null!;
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Editorial> Editorials { get; set; } = null!;
        public virtual DbSet<EstadoPrestamo> EstadoPrestamos { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
        public virtual DbSet<TipoPersona> TipoPersonas { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__Autor__DD33B031F86B0DE1");

                entity.ToTable("Autor", "Persona");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreAutor)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A10FDD542B7");

                entity.ToTable("Categoria", "Libro");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.HasKey(e => e.IdEditorial)
                    .HasName("PK__Editoria__EF83867167E562D6");

                entity.ToTable("Editorial", "Libro");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreEditorial)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoPrestamo>(entity =>
            {
                entity.HasKey(e => e.IdEstadoPrestamo)
                    .HasName("PK__EstadoPr__BCB87549155BD987");

                entity.ToTable("EstadoPrestamos", "Administrar");

                entity.Property(e => e.IdEstadoPrestamo).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK__Libro__3E0B49AD4BAC9D9A");

                entity.ToTable("Libro", "Libro");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("FK__Libro__IdAutor__38996AB5");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Libro__IdCategor__398D8EEE");

                entity.HasOne(d => d.IdEditorialNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdEditorial)
                    .HasConstraintName("FK__Libro__IdEditori__3A81B327");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Persona__2EC8D2ACCD061099");

                entity.ToTable("Persona", "Persona");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK_Persona_User");

                entity.HasOne(d => d.IdTipoPersonaNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdTipoPersona)
                    .HasConstraintName("FK__Persona__IdTipoP__4316F928");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.IdPrestamo)
                    .HasName("PK__Prestamo__6FF194C0CBB4600A");

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

                entity.HasOne(d => d.IdEstadoPrestamoNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdEstadoPrestamo)
                    .HasConstraintName("FK__Prestamo__IdEsta__48CFD27E");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdLibro)
                    .HasConstraintName("FK__Prestamo__IdLibr__4AB81AF0");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__Prestamo__IdPers__49C3F6B7");
            });

            modelBuilder.Entity<TipoPersona>(entity =>
            {
                entity.HasKey(e => e.IdTipoPersona)
                    .HasName("PK__Tipo_Per__79FCAFBFE4D43734");

                entity.ToTable("Tipo_Persona", "Persona");

                entity.Property(e => e.IdTipoPersona).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
