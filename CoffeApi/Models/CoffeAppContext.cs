using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoffeApi.Models
{
    public partial class CoffeAppContext : DbContext
    {
        public CoffeAppContext()
        {
        }

        public CoffeAppContext(DbContextOptions<CoffeAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; }
        public virtual DbSet<ElementoEnMenu> ElementoEnMenus { get; set; }
        public virtual DbSet<ElementoEnPaquete> ElementoEnPaquetes { get; set; }
        public virtual DbSet<MenuComidaCorridum> MenuComidaCorrida { get; set; }
        public virtual DbSet<Paquete> Paquetes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<ProductosEnVentum> ProductosEnVenta { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Ventum> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=RUDY;Initial Catalog=CoffeApp;Integrated Security=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.ToTable("CategoriaProducto");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ElementoEnMenu>(entity =>
            {
                entity.ToTable("ElementoEnMenu");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.IdMenuComidaCorrida)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdProducto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMenuComidaCorridaNavigation)
                    .WithMany(p => p.ElementoEnMenus)
                    .HasForeignKey(d => d.IdMenuComidaCorrida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ElementoEnMenu_MenuComidaCorrida");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ElementoEnMenus)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ElementoEnMenu_Producto");
            });

            modelBuilder.Entity<ElementoEnPaquete>(entity =>
            {
                entity.ToTable("ElementoEnPaquete");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Foto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdMenuComidaCorrida)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idMenuComidaCorrida");

                entity.Property(e => e.IdPaquete)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idPaquete");

                entity.Property(e => e.IdProducto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idProducto");

                entity.HasOne(d => d.IdMenuComidaCorridaNavigation)
                    .WithMany(p => p.ElementoEnPaquetes)
                    .HasForeignKey(d => d.IdMenuComidaCorrida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ElementoEnPaquete_MenuComidaCorrida");

                entity.HasOne(d => d.IdPaqueteNavigation)
                    .WithMany(p => p.ElementoEnPaquetes)
                    .HasForeignKey(d => d.IdPaquete)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ElementoEnPaquete_Paquete");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ElementoEnPaquetes)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ElementoEnPaquete_Producto");
            });

            modelBuilder.Entity<MenuComidaCorridum>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Costo).HasColumnType("money");

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Foto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paquete>(entity =>
            {
                entity.ToTable("Paquete");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Costo).HasColumnType("money");

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Costo).HasColumnType("money");

                entity.Property(e => e.Descriipcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_CategoriaProducto");
            });

            modelBuilder.Entity<ProductosEnVentum>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Costo).HasColumnType("money");

                entity.Property(e => e.IdMenu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idMenu");

                entity.Property(e => e.IdPaquete)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idPaquete");

                entity.Property(e => e.IdProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idProducto");

                entity.Property(e => e.IdVenta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idVenta");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.ProductosEnVenta)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK_ProductosEnVenta_MenuComidaCorrida");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ProductosEnVenta)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_ProductosEnVenta_Producto");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.ProductosEnVenta)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosEnVenta_Venta");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TipoUsuario");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Credito).HasColumnType("money");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nota).HasColumnType("text");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_TipoUsuario");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.Property(e => e.IdCliente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idCliente");

                entity.Property(e => e.IdVendedor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idVendedor");

                entity.Property(e => e.Monto).HasColumnType("money");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.VentumIdClienteNavigations)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Usuario");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.VentumIdVendedorNavigations)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_Venta_Usuario1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
