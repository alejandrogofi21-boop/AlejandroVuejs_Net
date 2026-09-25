using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[Index("Nombre", Name = "UQ__Generaci__75E3EFCF55C58E5F", IsUnique = true)]
public partial class Generacione
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Generacion")]
    public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}
