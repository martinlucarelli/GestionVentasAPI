

using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public class Categoria
{
    public Guid idCategoria {get;set;}
    public string? nombreCategoria {get;set;}
    public string? descripcion {get;set;}

   
    [JsonIgnore]
    
    public ICollection<Producto> productos {get;set;} //Relacion con producto
}