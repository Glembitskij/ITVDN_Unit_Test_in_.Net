using _033_InMemory_Cosmos.Cosmos;
using _033_InMemory_Cosmos;
using _033_InMemory_Cosmos.Options;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Налаштування CosmosDB
builder.Services.Configure<CosmosDbOptions>(builder.Configuration.GetSection("CosmosDb"));
builder.Services.AddSingleton<CosmosDbOptions>(provider =>
{
    return provider.GetRequiredService<IOptions<CosmosDbOptions>>().Value;
});

// Реєстрація Entity Framework Core для Cosmos DB
builder.Services.AddDbContext<AppDbContext>((provider, options) =>
{
    var cosmosOptions = provider.GetRequiredService<CosmosDbOptions>();
    options.UseCosmos(cosmosOptions.AccountEndpoint, cosmosOptions.AuthKey, cosmosOptions.DatabaseName);
});

// Реєстрація репозиторію
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Додаємо контролери
builder.Services.AddControllers();

// Додаємо Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Product API",
        //Version = "v1",
        //Description = "ASP.NET Core Web API with Cosmos DB",
        //Contact = new OpenApiContact
        //{
        //    Name = "Oleksii",
        //    Email = "oleksii@example.com",
        //    Url = new Uri("https://github.com/your-profile")
        //}
    });
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    appDbContext.Database.EnsureCreatedAsync().Wait();
}

// Додаємо Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API v1");
    });
}

app.UseAuthorization();
app.MapControllers();
// https://localhost:7239/swagger/index.html
app.Run();
