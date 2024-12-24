

public class Categoria
{
    public Guid idCategoria {get;set;}
    public string? nombreCategoria {get;set;}
    public string? descripcion {get;set;}

    public ICollection<Producto> productos {get;set;} //Relacion con producto
}