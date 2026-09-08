using System.ComponentModel.DataAnnotations;

namespace _2026web3.Pages.Personas;

public sealed class PersonaInputModel : IValidatableObject
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar 100 caracteres.")]
    [Display(Name = "Nombre completo")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de nacimiento")]
    public DateOnly? FechaNacimiento { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Selecciona un país.")]
    [Display(Name = "País")]
    public int PaisId { get; set; }

    [Required(ErrorMessage = "El número de pasaporte es obligatorio.")]
    [StringLength(30, ErrorMessage = "El pasaporte no puede superar 30 caracteres.")]
    [Display(Name = "Número de pasaporte")]
    public string NumeroPasaporte { get; set; } = string.Empty;

    public List<int> MateriaIds { get; set; } = [];

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (FechaNacimiento is not null && FechaNacimiento > DateOnly.FromDateTime(DateTime.Today))
        {
            yield return new ValidationResult(
                "La fecha de nacimiento no puede ser futura.",
                [nameof(FechaNacimiento)]);
        }
    }
}
