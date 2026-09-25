// Ajusta "WebApplication1" al namespace raiz real de tu proyecto (ej. Pokemon.Api)
// si tu proyecto se llama distinto.
namespace WebApplication1.Models.Dtos;

// DTO = Data Transfer Object. Es la "forma" exacta de datos que el frontend
// va a recibir, separada de como esta modelada la base de datos.
public class PokemonDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Generacion { get; set; } = null!;
    public string? Habilidad { get; set; }
    public string? Naturaleza { get; set; }
    public string? Objeto { get; set; }
    public string? Rol { get; set; }
    public List<string> Tipos { get; set; } = new();
    public List<string> Movimientos { get; set; } = new();
    public List<string> Imagenes { get; set; } = new();
}
