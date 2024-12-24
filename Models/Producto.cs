

public class Producto
{
    public Guid idProdcuto {get;set;}
    public string? nombreProducto {get;set;}
    public double precio {get;set;}
    public int cantidadStock {get;set;}
    public Guid categoriaId {get;set;} //clave foranea

    public Categoria categoria{get;set;}
    public ICollection<DetalleVenta> detalleVentas{get;set;} //relacion con detalle ventas
}