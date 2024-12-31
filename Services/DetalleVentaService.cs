

public class    DetalleVentaService : IDetalleVentaService
{

    VentasContext context;

    public DetalleVentaService(VentasContext bdcontext)
    {

        context=bdcontext;
    }

    public IEnumerable<DetalleVenta> Get()
    {
        return context.DetalleVentas;
    }   

    public async Task Save(List<DetalleVentaDTO> lsitaDetalleVenta)
    {
        try
        {
            foreach(var dvDTO in lsitaDetalleVenta)
            {
                var detalleVenta = new DetalleVenta
                {
                    cantidad=dvDTO.cantidad,
                    subtotal=dvDTO.subtotal,
                    ventaId=dvDTO.ventaId,
                    productoId=dvDTO.productoId
                };


                context.Add(detalleVenta);
            }
            await context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
           System.Console.WriteLine(ex.Message + ": Erro del metodo save (DetalleVentaService.cs)");
        }
    }

    public IEnumerable<DetalleVenta> GetDetalle(Guid idVenta)
    {
        try
        {
            return context.DetalleVentas.Where(dv=> dv.ventaId == idVenta).ToList();   
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message + "ERROR DEL METODO GETDETALLE (VentaService.cs)");
            return Enumerable.Empty<DetalleVenta>();
        }

    }


}


public interface IDetalleVentaService
{
    IEnumerable<DetalleVenta> Get();
    Task Save(List<DetalleVentaDTO> lsitaDetalleVenta);
    IEnumerable<DetalleVenta> GetDetalle(Guid idVenta);

}