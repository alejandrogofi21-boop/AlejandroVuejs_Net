using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[Table("Pokemon")]
public partial class Pokemon
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    public int GeneracionId { get; set; }

    [StringLength(100)]
    public string? Habilidad { get; set; }

    [StringLength(50)]
    public string? Naturaleza { get; set; }

    [StringLength(100)]
    public string? Objeto { get; set; }

    [StringLength(50)]
    public string? Rol { get; set; }

    [ForeignKey("GeneracionId")]
    [InverseProperty("Pokemons")]
    public virtual Generacione Generacion { get; set; } = null!;

    [InverseProperty("Pokemon")]
    public virtual ICollection<PokemonImagene> PokemonImagenes { get; set; } = new List<PokemonImagene>();

    [ForeignKey("PokemonId")]
    [InverseProperty("Pokemons")]
    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    [ForeignKey("PokemonId")]
    [InverseProperty("Pokemons")]
    public virtual ICollection<Tipo> Tipos { get; set; } = new List<Tipo>();
}
