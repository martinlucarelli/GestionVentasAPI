




public class ProductoService : IProductoService
{

    VentasContext context;

    public ProductoService(VentasContext bdcontext)
    {

        context=bdcontext;
    }

    public IEnumerable<Producto> Get()
    {
        return context.productos;
    }

    public async Task Save(List<ProductoDTO> listaProductos)
    {
        try
        {
            foreach(var proDTO in listaProductos)
            {
                var producto=new Producto
                {
                    nombreProducto=proDTO.nombreProducto,
                    precio=proDTO.precio,
                    cantidadStock=proDTO.cantidadStock,
                    categoriaId=proDTO.categoriaId

                };
                
                context.Add(producto);
            }
            await context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message + ": Erro del metodo save (ProductoService.cs)");
        }
    }


}


public interface IProductoService
{
    IEnumerable<Producto> Get();
    Task Save(List<ProductoDTO> listaProductos);

}