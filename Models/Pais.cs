using System.ComponentModel.DataAnnotations;

namespace _2026web3.Models;

public class Pais
{
    public int Id { get; set; }

    [Required, StringLength(80)]
    public string Name { get; set; } = string.Empty;

    public List<Persona> Personas { get; set; } = [];
}
