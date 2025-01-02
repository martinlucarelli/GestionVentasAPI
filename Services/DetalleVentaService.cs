

using Microsoft.IdentityModel.Tokens;

public class    DetalleVentaService : IDetalleVentaService
{

    VentasContext context;
    public readonly  ILogger<DetalleVenta>_logger;

    public DetalleVentaService(VentasContext bdcontext, ILogger<DetalleVenta> logger)
    {

        context=bdcontext;
        _logger=logger;
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
           _logger.LogError(ex.Message + ": Erro del metodo save (DetalleVentaService.cs)");
        }
    }

    public IEnumerable<DetalleVenta> GetDetalle(Guid idVenta)
    {
        try
        {
            var Detalles= context.DetalleVentas.Where(dv=> dv.ventaId == idVenta).ToList();

            if(Detalles.IsNullOrEmpty())
            {
                _logger.LogError("NO SE ENCONTRO LA VENTA DE LA QUE SE QUIERE MOSTRAR EL DETALLE (VERIFICAR ID)");
            }
            return Detalles;
              
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message + "ERROR DEL METODO GETDETALLE (VentaService.cs)");
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