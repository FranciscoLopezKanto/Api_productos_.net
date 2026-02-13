using CrudMongoApi.Config;
using CrudMongoApi.Services;
using DotNetEnv;

// Cargar variables de entorno desde el archivo .env
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Configurar MongoDB desde variables de entorno
builder.Services.Configure<MongoDbSettings>(options =>
{
    options.ConnectionString = Environment.GetEnvironmentVariable("mongodb_uri") ?? "";
    options.DatabaseName = "test";
    options.CollectionName = "products";
});

// Add services to the container.
builder.Services.AddSingleton<ProductService>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Mapear los controladores
app.MapControllers();

app.Run();
