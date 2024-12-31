



using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route ("[controller]")]

public class CategoriaController : ControllerBase
{

    ICategoriaService categoriaService;
    VentasContext context;

    public CategoriaController(ICategoriaService service,VentasContext dbcontext)
    {
        categoriaService=service;
        context= dbcontext;
    }


    [HttpGet]

    public IActionResult Get()
    {
        context.Database.EnsureCreated();
        return Ok(categoriaService.Get());
    }




    [HttpPost]
    public async Task<IActionResult> Post ([FromBody] List<CategoriaDTO> listaCategoriasRecibidas)
    {
        
        await categoriaService.Save(listaCategoriasRecibidas);
        return Ok();
    }

    [HttpPost ("{id}")]


    [HttpDelete("{id}")]


    public async Task<IActionResult> Delete (Guid id)
    {
        await categoriaService.Delete(id);
        return NoContent();
    }

    [HttpPatch("{id}")]

    public async Task<IActionResult> Patch(Guid id, [FromBody] CategoriaDTO catupd)
    {

        await categoriaService.Update(id,catupd);
        
        return Ok();

    }

}

