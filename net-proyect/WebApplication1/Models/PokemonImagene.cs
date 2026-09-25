using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class PokemonImagene
{
    [Key]
    public int Id { get; set; }

    public int PokemonId { get; set; }

    [StringLength(200)]
    public string NombreArchivo { get; set; } = null!;

    [ForeignKey("PokemonId")]
    [InverseProperty("PokemonImagenes")]
    public virtual Pokemon Pokemon { get; set; } = null!;
}
