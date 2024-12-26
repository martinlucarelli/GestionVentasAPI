


using System.Data.Common;
using Azure.Core;

public class CategoriaService : ICategoriaService
{

    VentasContext context;

    public CategoriaService(VentasContext bdcontext)
    {

        context=bdcontext;
    }

    public IEnumerable<Categoria> Get()
    {
        return context.categorias;
    }

    public async Task Save(List<CategoriaDTO> listaCategoriasRecibida)
    {
        try
        {
            foreach(var catDto in listaCategoriasRecibida)
            {   
                var categoria = new Categoria
                {
                    nombreCategoria= catDto.NombreCategoria,
                    descripcion=catDto.Descripcion
                };
                context.Add(categoria);
            }
            await context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message + ": Erro del metodo save (CategoriaService.cs)");
        }
    }


}


public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(List<CategoriaDTO> listaCategoriasRecibida);

}