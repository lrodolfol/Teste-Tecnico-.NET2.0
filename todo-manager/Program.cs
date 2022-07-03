using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using todo_manager.Models.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("StringConnApiTodoManager");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gerenciador de Todo's", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

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
    }catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Ocorreu erro ao executar o auto-migration.");
        Console.WriteLine("Por favor, tente executar o comando 'Add-Migration 'migration' manualmente");
    }
    
}

app.Run();