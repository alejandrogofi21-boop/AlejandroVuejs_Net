// Ajusta "WebApplication1" al namespace raiz real de tu proyecto (ej. Pokemon.Api)
// si tu proyecto se llama distinto.
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Dtos;

namespace WebApplication1.Controllers;

// [ApiController] activa validaciones automaticas y respuestas de error estandar.
// [Route] define la URL base: en este caso "api/pokemon"
[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    // El DbContext se "inyecta" via constructor (Inyeccion de Dependencias).
    // ASP.NET Core lo crea y entrega solo gracias a builder.Services.AddDbContext
    // que vamos a agregar en Program.cs.
    private readonly PokemonPBContext _context;

    public PokemonController(PokemonPBContext context)
    {
        _context = context;
    }

    // GET api/pokemon
    // GET api/pokemon?generacion=Gen I
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PokemonDto>>> GetPokemon([FromQuery] string? generacion)
    {
        // IQueryable: la consulta todavia NO se ejecuta contra SQL Server aqui,
        // se arma paso a paso y recien se dispara con ToListAsync().
        var query = _context.Pokemons
            .Include(p => p.Generacion)
            .Include(p => p.Tipos)
            .Include(p => p.Movimientos)
            .Include(p => p.PokemonImagenes)
            .AsQueryable();

        // Filtro opcional por generacion (para cuando el usuario elige un valor
        // en el <select> del frontend)
        if (!string.IsNullOrWhiteSpace(generacion))
        {
            query = query.Where(p => p.Generacion.Nombre == generacion);
        }

        var resultado = await query
            .OrderBy(p => p.Nombre)
            .Select(p => new PokemonDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Generacion = p.Generacion.Nombre,
                Habilidad = p.Habilidad,
                Naturaleza = p.Naturaleza,
                Objeto = p.Objeto,
                Rol = p.Rol,
                Tipos = p.Tipos.Select(t => t.Nombre).ToList(),
                Movimientos = p.Movimientos.Select(m => m.Nombre).ToList(),
                Imagenes = p.PokemonImagenes.Select(i => i.NombreArchivo).ToList()
            })
            .ToListAsync();

        return Ok(resultado);
    }

    // GET api/pokemon/generaciones
    // Endpoint auxiliar para llenar el <select> del frontend con la lista
    // de generaciones disponibles.
    [HttpGet("generaciones")]
    public async Task<ActionResult<IEnumerable<string>>> GetGeneraciones()
    {
        var generaciones = await _context.Generaciones
            .OrderBy(g => g.Id)
            .Select(g => g.Nombre)
            .ToListAsync();

        return Ok(generaciones);
    }
}