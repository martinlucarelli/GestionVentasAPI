




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
                    precio=(double)proDTO.precio,
                    cantidadStock=(int)proDTO.cantidadStock,
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

    public async Task Delete(Guid idEliminar)
    {
        try
        {
            var productoAEliminar = await context.productos.FindAsync(idEliminar);

            if(productoAEliminar != null)
            {
                context.productos.Remove(productoAEliminar);
                
                
            }
            else
            {
                System.Console.WriteLine("NO SE ENCONTRO EL PRODUCTO QUE SE DESEA ELIMINAR");
            }
            
            await context.SaveChangesAsync();

        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message + "ERROR DEL METODO DELETE (ProductoService.cs)");
        }
    }

    public async Task Update(Guid id, ProductoDTO produpd)
    {
        try
        {
            var prodExistente = await context.productos.FindAsync(id);

            if(prodExistente != null)
            {
                if(!string.IsNullOrEmpty(produpd.nombreProducto))
                {
                    prodExistente.nombreProducto=produpd.nombreProducto;
                }
                if(produpd.precio.HasValue && produpd.precio > 0)
                {
                    prodExistente.precio= (double)produpd.precio;
                }
                if(produpd.cantidadStock.HasValue && produpd.cantidadStock >=0)
                {
                    prodExistente.cantidadStock=(int)produpd.cantidadStock;
                }
                if(produpd.categoriaId != Guid.Empty)
                {
                    prodExistente.categoriaId=produpd.categoriaId;
                }

            }
            else
            {
                System.Console.WriteLine("NO SE ENCONTRO EL REGISTRO QUE SE QUIERE MODIFICAR");
            }

            await context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message + "ERROR EN EL METODO UPDTAE (ProductoService.cs)");
        }




    }



}


public interface IProductoService
{
    IEnumerable<Producto> Get();
    Task Save(List<ProductoDTO> listaProductos);
    Task Delete(Guid id);
    Task Update(Guid id, ProductoDTO produpd);

}