
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

    [HttpDelete ("{id}")]

    public async Task<IActionResult> Delete(Guid id)
    {
        await productoService.Delete(id);
        return NoContent();
    }

    [HttpPatch ("{id}")]

    public async Task<IActionResult> Patch(Guid id,[FromBody] ProductoDTO prodUpd)
    {   
        await productoService.Update(id,prodUpd);

        return Ok();

    } 

}