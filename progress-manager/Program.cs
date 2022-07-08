using CardsManagerLib.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using progress_manager.Models.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connectionString = builder.Configuration.GetConnectionString("StringConnApiTodoManager");
var connectionString = builder.Configuration.GetConnectionString("StringConnApiTodoManagerDocker");

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IContextCard, ContextCard>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gerenciador de Progress", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();

        Console.WriteLine("Auto migration foi executado");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Ocorreu erro ao executar o auto-migration.");
        Console.WriteLine("Verifique se a string de conexão esta corretamente configurada.");
        Console.WriteLine("Por favor, tente executar o comando 'Add-Migration 'migration' manualmente");
    }

}

app.Run();
