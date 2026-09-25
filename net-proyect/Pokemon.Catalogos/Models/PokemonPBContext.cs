using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pokemon.Catalogos.Models;

public partial class PokemonPBContext : DbContext
{
    public PokemonPBContext()
    {
    }

    public PokemonPBContext(DbContextOptions<PokemonPBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:PokemonPBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movimien__3214EC07F50F08EF");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tipos__3214EC072A7194F8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
