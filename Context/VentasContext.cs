



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
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria(){idCategoria=Guid.Parse("11111111-1111-1111-1111-111111111111"),nombreCategoria="Higiene personal"});
        categoriasInit.Add(new Categoria(){idCategoria=Guid.Parse("22222222-2222-2222-2222-222222222222"),nombreCategoria="Repelentes",descripcion="Articulos repeletes y antiplagas"});
        categoriasInit.Add(new Categoria(){idCategoria=Guid.Parse("33333333-3333-3333-3333-333333333333"),nombreCategoria="Limpieza"});

        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(c=> c.idCategoria);
            categoria.Property(c=> c.idCategoria).ValueGeneratedOnAdd(); //Se genera automaticamente al agregar un resgistro
            categoria.Property(c=> c.nombreCategoria).IsRequired();
            categoria.Property(c=> c.descripcion).IsRequired(false);

            categoria.HasData(categoriasInit);
        });

        List<Producto> productosInit = new List<Producto>();
        productosInit.Add(new Producto(){idProdcuto=Guid.Parse("44444444-4444-4444-4444-444444444444"),nombreProducto="Jabon",precio=800,cantidadStock=80,categoriaId=Guid.Parse("11111111-1111-1111-1111-111111111111")});
        productosInit.Add(new Producto(){idProdcuto=Guid.Parse("55555555-5555-5555-5555-555555555555"),nombreProducto="Esprial",precio=200,cantidadStock=150,categoriaId=Guid.Parse("22222222-2222-2222-2222-222222222222")});
        productosInit.Add(new Producto(){idProdcuto=Guid.Parse("66666666-6666-6666-6666-666666666666"),nombreProducto="Lavandina",precio=2400,cantidadStock=34,categoriaId=Guid.Parse("33333333-3333-3333-3333-333333333333")});

        modelBuilder.Entity<Producto>(producto =>
        {
            producto.ToTable("Producto");
            producto.HasKey(p=>p.idProdcuto);
            producto.Property(p=>p.idProdcuto).ValueGeneratedOnAdd();
            producto.Property(p=>p.nombreProducto).IsRequired();
            producto.Property(p=>p.cantidadStock).IsRequired();
            producto.HasOne(p=>p.categoria).WithMany(c=>c.productos).HasForeignKey(c=>c.categoriaId);//calve foranea

            producto.HasData(productosInit);
        });

        /*List<Venta> ventasInit= new List<Venta>();
        ventasInit.Add(new Venta(){idVenta=Guid.Parse("77777777-7777-7777-7777-777777777777"),fecha=DateTime.Now,total=4400});
        ventasInit.Add(new Venta(){idVenta=Guid.Parse("88888888-8888-8888-8888-888888888888"),fecha=DateTime.Now,total=7200});*/

        modelBuilder.Entity<Venta>(venta=>
        {
            venta.ToTable("Venta");
            venta.HasKey(v=> v.idVenta);
            venta.Property(v=>v.fecha).ValueGeneratedOnAdd();
            venta.Property(v=>v.total).IsRequired();

            //venta.HasData(ventasInit);
        });

        List<DetalleVenta> detalleVentasInit = new List<DetalleVenta>();

        detalleVentasInit.Add(new DetalleVenta(){idDetalleVenta=Guid.NewGuid(),cantidad=2,subtotal=1600,productoId=Guid.Parse("44444444-4444-4444-4444-444444444444"),ventaId=Guid.Parse("77777777-7777-7777-7777-777777777777")});
        detalleVentasInit.Add(new DetalleVenta(){idDetalleVenta=Guid.NewGuid(),cantidad=2,subtotal=400,productoId=Guid.Parse("55555555-5555-5555-5555-555555555555"),ventaId=Guid.Parse("77777777-7777-7777-7777-777777777777")});
        detalleVentasInit.Add(new DetalleVenta(){idDetalleVenta=Guid.NewGuid(),cantidad=2,subtotal=1600,productoId=Guid.Parse("66666666-6666-6666-6666-666666666666"),ventaId=Guid.Parse("77777777-7777-7777-7777-777777777777")});

        // 2da venta
        detalleVentasInit.Add(new DetalleVenta(){idDetalleVenta=Guid.NewGuid(),cantidad=3,subtotal=2400,productoId=Guid.Parse("44444444-4444-4444-4444-444444444444"),ventaId=Guid.Parse("88888888-8888-8888-8888-888888888888")});
        detalleVentasInit.Add(new DetalleVenta(){idDetalleVenta=Guid.NewGuid(),cantidad=2,subtotal=4800,productoId=Guid.Parse("66666666-6666-6666-6666-666666666666"),ventaId=Guid.Parse("88888888-8888-8888-8888-888888888888")});


        modelBuilder.Entity<DetalleVenta>(DetVen=>
        {
            DetVen.ToTable("DetalleVenta");
            DetVen.HasKey(dv=>dv.idDetalleVenta);
            DetVen.Property(dv=>dv.idDetalleVenta).ValueGeneratedOnAdd();
            DetVen.Property(dv=> dv.cantidad).IsRequired();
            DetVen.Property(dv=>dv.subtotal).IsRequired();
            DetVen.HasOne(dv=>dv.venta).WithMany(v=>v.detalleVentas).HasForeignKey(dv=>dv.ventaId);
            DetVen.HasOne(dv=>dv.producto).WithMany(p=>p.detalleVentas).HasForeignKey(dv=>dv.productoId);

            DetVen.HasData(detalleVentasInit);
        });


    }

}