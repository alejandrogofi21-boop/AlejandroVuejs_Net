using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pokemon.Catalogos.Models;

[Index("Nombre", Name = "UQ__Tipos__75E3EFCF896E024D", IsUnique = true)]
public partial class Tipo
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string Nombre { get; set; } = null!;
}
