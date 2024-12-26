


using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route ("[controller]")]

public class DetalleVentaController : ControllerBase
{

    IDetalleVentaService detalleVentaService;
    VentasContext context;

    public DetalleVentaController(IDetalleVentaService service,VentasContext dbcontext)
    {
        detalleVentaService=service;
        context= dbcontext;
    }


    [HttpGet]

    public IActionResult Get()
    {
        
        return Ok(detalleVentaService.Get());
    }

    [HttpPost]

    public async Task<IActionResult> Post ([FromBody] List<DetalleVentaDTO> listaDetalleVentas)
    {
        await detalleVentaService.Save(listaDetalleVentas);
        return Ok();
    }

}