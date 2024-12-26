



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

public class VentasContext : DbContext
{

    public DbSet<Categoria> categorias {get;set;}
    public DbSet<Producto> productos {get;set;}
    public DbSet<Venta> ventas {get;set;}
    public DbSet<DetalleVenta> DetalleVentas {get;set;}

    public VentasContext (DbContextOptions<VentasContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(c=> c.idCategoria);
            categoria.Property(c=> c.idCategoria).ValueGeneratedOnAdd(); //Se genera automaticamente al agregar un resgistro
            categoria.Property(c=> c.nombreCategoria).IsRequired();
            categoria.Property(c=> c.descripcion).IsRequired(false);
        });

        modelBuilder.Entity<Producto>(producto =>
        {
            producto.ToTable("Producto");
            producto.HasKey(p=>p.idProdcuto);
            producto.Property(p=>p.idProdcuto).ValueGeneratedOnAdd();
            producto.Property(p=>p.nombreProducto).IsRequired();
            producto.Property(p=>p.cantidadStock).IsRequired();
            producto.HasOne(p=>p.categoria).WithMany(c=>c.productos).HasForeignKey(c=>c.categoriaId);//calve foranea

             
        });

        modelBuilder.Entity<Venta>(venta=>
        {
            venta.ToTable("Venta");
            venta.HasKey(v=> v.idVenta);
            venta.Property(v=>v.fecha).ValueGeneratedOnAdd();
            venta.Property(v=>v.total).IsRequired();
        });

        modelBuilder.Entity<DetalleVenta>(DetVen=>
        {
            DetVen.ToTable("DetalleVenta");
            DetVen.HasKey(dv=>dv.idDetalleVenta);
            DetVen.Property(dv=>dv.idDetalleVenta).ValueGeneratedOnAdd();
            DetVen.Property(dv=> dv.cantidad).IsRequired();
            DetVen.Property(dv=>dv.subtotal).IsRequired();
            DetVen.HasOne(dv=>dv.venta).WithMany(v=>v.detalleVentas).HasForeignKey(dv=>dv.ventaId);
            DetVen.HasOne(dv=>dv.producto).WithMany(p=>p.detalleVentas).HasForeignKey(dv=>dv.productoId);
        });


    }

}