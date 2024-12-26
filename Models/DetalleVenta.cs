


using System.Text.Json.Serialization;

public class DetalleVenta
{
    public Guid idDetalleVenta {get;set;}
    public int cantidad {get;set;}
    public decimal subtotal {get;set;}
    public Guid productoId {get;set;} //clave foranea
    public Guid ventaId {get;set;} // clave foranea

    [JsonIgnore]
   public Producto producto {get;set;}
   [JsonIgnore]
   public Venta venta {get;set;}
}