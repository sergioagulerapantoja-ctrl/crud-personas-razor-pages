using System.ComponentModel.DataAnnotations;

namespace _2026web3.Models;

public class Persona
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateOnly dob { get; set; }

    public Pasaporte? Pasaporte { get; set; }

    public int paisId { get; set; }
    public Pais Pais { get; set; } = null!;

    public List<Materia> Materias { get; set; } = [];
}
