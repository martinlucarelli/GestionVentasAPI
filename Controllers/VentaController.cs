
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route ("[controller]")]

public class VentaController : ControllerBase
{

    IVentaService ventaService;
    VentasContext context;

    public VentaController(IVentaService service,VentasContext dbcontext)
    {
        ventaService=service;
        context= dbcontext;
    }


    [HttpGet]

    public IActionResult Get()
    {
        
        try
        {
            return Ok(ventaService.Get());
        }
        catch(Exception ex)
        {
            string merror= ex.Message + "ERROR CONTROLLER VENTA";
            return Ok(merror);
        }

        
    }

    [HttpPost]

    public async Task<IActionResult> Post ([FromBody] List<VentaDTO> listaVentas)
    {
        await ventaService.Save(listaVentas);
        return Ok();
    }

}
