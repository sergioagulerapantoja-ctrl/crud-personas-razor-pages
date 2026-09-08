using _2026web3.Models;
using Microsoft.EntityFrameworkCore;

namespace _2026web3.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
    {
    }

    public DbSet<Persona> Personas { get; set; }
    public DbSet<Pasaporte> Pasaporte { get; set; }
    public DbSet<Pais> Pais { get; set; }
    public DbSet<Materia> Materia { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Persona>()
            .HasOne(p => p.Pasaporte)
            .WithOne(pe => pe.Persona)
            .HasForeignKey<Pasaporte>(pa => pa.personaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Pasaporte>()
            .HasIndex(p => p.Numero)
            .IsUnique();

        modelBuilder.Entity<Persona>()
            .HasOne(p => p.Pais)
            .WithMany(pe => pe.Personas)
            .HasForeignKey(pa => pa.paisId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Persona>()
            .HasMany(p => p.Materias)
            .WithMany(m => m.Personas)
            .UsingEntity(j => j.ToTable("Inscripcion"));

        modelBuilder.Entity<Pais>().HasData(
            new Pais { Id = 1, Name = "Bolivia" },
            new Pais { Id = 2, Name = "Argentina" },
            new Pais { Id = 3, Name = "Brasil" },
            new Pais { Id = 4, Name = "Chile" },
            new Pais { Id = 5, Name = "Perú" });

        modelBuilder.Entity<Materia>().HasData(
            new Materia { Id = 1, Name = "Programación Web", Creditos = 4 },
            new Materia { Id = 2, Name = "Base de Datos", Creditos = 4 },
            new Materia { Id = 3, Name = "Ingeniería de Software", Creditos = 3 },
            new Materia { Id = 4, Name = "Redes", Creditos = 3 });
    }
}
