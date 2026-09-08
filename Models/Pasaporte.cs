using System.ComponentModel.DataAnnotations;

namespace _2026web3.Models;

public class Pasaporte
{
    public int Id { get; set; }

    [Required, StringLength(30)]
    public string Numero { get; set; } = string.Empty;

    public int personaId { get; set; }
    public Persona Persona { get; set; } = null!;
}
