var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion de dependencias
builder.Services.AddScoped<ICategoriaService,CategoriaService>();
builder.Services.AddScoped<IVentaService,VentaService>();
builder.Services.AddScoped<IDetalleVentaService,DetalleVentaService>();
builder.Services.AddScoped<IProductoService,ProductoService>();

//
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });




//Conexion con base de datos
builder.Services.AddSqlServer<VentasContext>(builder.Configuration.GetConnectionString("cnBaseDeDatos"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
