

public class Venta
{
    public Guid idVenta {get;set;}
    public DateTime fecha {get;set;}
    public decimal total {get;set;}

    public ICollection<DetalleVenta> detalleVentas {get;set;}
}