using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class PokemonPBContext : DbContext
{
    public PokemonPBContext()
    {
    }

    public PokemonPBContext(DbContextOptions<PokemonPBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Generacione> Generaciones { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    public virtual DbSet<PokemonImagene> PokemonImagenes { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:PokemonPBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Generacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Generaci__3214EC0728FF1D74");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movimien__3214EC07F50F08EF");
        });

        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pokemon__3214EC073AFEAB5B");

            entity.HasOne(d => d.Generacion).WithMany(p => p.Pokemons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pokemon_Generaciones");

            entity.HasMany(d => d.Movimientos).WithMany(p => p.Pokemons)
                .UsingEntity<Dictionary<string, object>>(
                    "PokemonMovimiento",
                    r => r.HasOne<Movimiento>().WithMany()
                        .HasForeignKey("MovimientoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PokemonMovimientos_Movimiento"),
                    l => l.HasOne<Pokemon>().WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PokemonMovimientos_Pokemon"),
                    j =>
                    {
                        j.HasKey("PokemonId", "MovimientoId").HasName("PK__PokemonM__B23DCAE15845F087");
                        j.ToTable("PokemonMovimientos");
                    });

            entity.HasMany(d => d.Tipos).WithMany(p => p.Pokemons)
                .UsingEntity<Dictionary<string, object>>(
                    "PokemonTipo",
                    r => r.HasOne<Tipo>().WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PokemonTipos_Tipos"),
                    l => l.HasOne<Pokemon>().WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PokemonTipos_Pokemon"),
                    j =>
                    {
                        j.HasKey("PokemonId", "TipoId").HasName("PK__PokemonT__00B470C862B579E1");
                        j.ToTable("PokemonTipos");
                    });
        });

        modelBuilder.Entity<PokemonImagene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PokemonI__3214EC07DB83DEBC");

            entity.HasOne(d => d.Pokemon).WithMany(p => p.PokemonImagenes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PokemonImagenes_Pokemon");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tipos__3214EC072A7194F8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
