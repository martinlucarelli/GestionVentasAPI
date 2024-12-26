

using System.Text.Json.Serialization;

public class Venta
{
    public Guid idVenta {get;set;}
    public DateTime fecha {get;set;}
    public decimal total {get;set;}

    [JsonIgnore]
    public ICollection<DetalleVenta> detalleVentas {get;set;}
}