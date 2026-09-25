using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pokemon.Catalogos.Models;

[Index("Nombre", Name = "UQ__Movimien__75E3EFCF2936CBEB", IsUnique = true)]
public partial class Movimiento
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;
}
