


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

    public async Task Delete(Guid idEliminar)
    {
        try
        {
            var categoriaEliminar = await context.categorias.FindAsync(idEliminar);
            
            if(categoriaEliminar != null)
            {
                context.categorias.Remove(categoriaEliminar);
            }
            else
            {
                System.Console.WriteLine("No se encontro la cateogria que se desea eliminar");
            }


            await context.SaveChangesAsync();

        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message + "ERROR DEL METODO DELETE (CategoriaService.cs)");
        }

    }

    public async Task Update(Guid id, CategoriaDTO catUpd )
    {

        try
        {
            var categoriaExistente= await context.categorias.FindAsync(id);

            if(categoriaExistente!= null)
            {


                if(!string.IsNullOrEmpty(catUpd.NombreCategoria))
                {
                    categoriaExistente.nombreCategoria=catUpd.NombreCategoria;
                }
                if(!string.IsNullOrEmpty(catUpd.Descripcion))
                {
                    categoriaExistente.descripcion=catUpd.Descripcion;
                }
                
                await context.SaveChangesAsync();
            }
            else
            {
                System.Console.WriteLine("No se encontro la categoria que desea modificar");
            }


        }   
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message + "ERROR EN EL METODO UPDATE (categoriaService.cs)");
        }

    }


}


public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(List<CategoriaDTO> listaCategoriasRecibida);
    Task Delete(Guid idEliminar);
    Task Update(Guid id, CategoriaDTO catUpd);

}