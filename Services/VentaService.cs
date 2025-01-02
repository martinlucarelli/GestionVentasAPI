



public class VentaService : IVentaService
{

    VentasContext context;
    public readonly ILogger<VentaService> _logger;

    public VentaService(VentasContext bdcontext,ILogger<VentaService> logger)
    {

        context = bdcontext;    
        _logger=logger;
    }

    public IEnumerable<Venta> Get()
    {
        try
        {
            return context.ventas;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message + "ERROR GET VENTA");
            return context.ventas;
        }
    }

    public async Task Save(List<VentaDTO> listaVentas)
    {
        try
        {
            foreach (var venDTO in listaVentas)
            {
                var venta = new Venta
                {
                    fecha = DateTime.Now,
                    total = venDTO.total
                };


                context.Add(venta);
            }
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message + ": Erro del metodo save (VentaService.cs)");
        }
    }




}
    

public interface IVentaService
{
    IEnumerable<Venta> Get();
    Task Save(List<VentaDTO> listaVentas);
    

}