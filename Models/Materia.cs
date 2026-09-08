using System.ComponentModel.DataAnnotations;

namespace _2026web3.Models;

public class Materia
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(1, 20)]
    public int Creditos { get; set; }

    public List<Persona> Personas { get; set; } = [];
}
