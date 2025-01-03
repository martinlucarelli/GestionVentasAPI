

using System.Text.Json.Serialization;

public class Producto
{
    public Guid idProdcuto {get;set;}
    public string? nombreProducto {get;set;}
    public double precio {get;set;}
    public int cantidadStock {get;set;}
    public Guid categoriaId {get;set;} //clave foranea

    [JsonIgnore]
    public Categoria categoria{get;set;}
    [JsonIgnore]
    public ICollection<DetalleVenta> detalleVentas{get;set;} //relacion con detalle ventas
}