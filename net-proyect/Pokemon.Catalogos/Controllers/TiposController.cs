// Ajusta "Pokemon.Catalogos" al namespace raiz real de tu proyecto si es distinto
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokemon.Catalogos.Models;

namespace Pokemon.Catalogos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TiposController : ControllerBase
{
    private readonly PokemonPBContext _context;

    public TiposController(PokemonPBContext context)
    {
        _context = context;
    }

    // GET api/tipos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tipo>>> GetTipos()
    {
        var tipos = await _context.Tipos
            .OrderBy(t => t.Nombre)
            .ToListAsync();

        return Ok(tipos);
    }

    // GET api/tipos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tipo>> GetTipo(int id)
    {
        var tipo = await _context.Tipos.FindAsync(id);

        if (tipo == null)
        {
            return NotFound();
        }

        return Ok(tipo);
    }
}
