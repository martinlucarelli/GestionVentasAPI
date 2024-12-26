
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route ("[controller]")]

public class ProductoController : ControllerBase
{

    IProductoService productoService;
    VentasContext context;

    public ProductoController(IProductoService service,VentasContext dbcontext)
    {
        productoService=service;
        context= dbcontext;
    }


    [HttpGet]

    public IActionResult Get()
    {
        
        return Ok(productoService.Get());
    }

    [HttpPost]

    public async Task<IActionResult> Post ([FromBody] List<ProductoDTO> listaProductos)
    {
        await productoService.Save(listaProductos);
        return Ok();
    }

}