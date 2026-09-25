// Ajusta "Pokemon.Catalogos" al namespace raiz real de tu proyecto si es distinto
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokemon.Catalogos.Models;

namespace Pokemon.Catalogos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimientosController : ControllerBase
{
    private readonly PokemonPBContext _context;

    public MovimientosController(PokemonPBContext context)
    {
        _context = context;
    }

    // GET api/movimientos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movimiento>>> GetMovimientos()
    {
        var movimientos = await _context.Movimientos
            .OrderBy(m => m.Nombre)
            .ToListAsync();

        return Ok(movimientos);
    }

    // GET api/movimientos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Movimiento>> GetMovimiento(int id)
    {
        var movimiento = await _context.Movimientos.FindAsync(id);

        if (movimiento == null)
        {
            return NotFound();
        }

        return Ok(movimiento);
    }
}