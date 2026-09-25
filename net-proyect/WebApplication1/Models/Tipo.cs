using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[Index("Nombre", Name = "UQ__Tipos__75E3EFCF896E024D", IsUnique = true)]
public partial class Tipo
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string Nombre { get; set; } = null!;

    [ForeignKey("TipoId")]
    [InverseProperty("Tipos")]
    public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}
