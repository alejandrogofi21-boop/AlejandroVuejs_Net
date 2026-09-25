using Microsoft.EntityFrameworkCore;
using Pokemon.Catalogos.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokemonPBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PokemonPBConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors("PermitirFrontend");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();