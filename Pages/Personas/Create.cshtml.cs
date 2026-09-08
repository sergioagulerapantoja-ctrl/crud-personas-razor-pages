using _2026web3.Data;
using _2026web3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _2026web3.Pages.Personas;

public class CreateModel(ApplicationDbContext context) : PageModel
{
    [BindProperty]
    public PersonaInputModel Input { get; set; } = new();

    public IReadOnlyList<SelectListItem> Paises { get; private set; } = [];
    public IReadOnlyList<Materia> Materias { get; private set; } = [];

    public async Task OnGetAsync() => await LoadCatalogsAsync();

    public async Task<IActionResult> OnPostAsync()
    {
        await LoadCatalogsAsync();
        var numeroPasaporte = Input.NumeroPasaporte.Trim();

        if (Input.PaisId > 0 && !Paises.Any(p => p.Value == Input.PaisId.ToString()))
        {
            ModelState.AddModelError("Input.PaisId", "El país seleccionado no existe.");
        }

        var materiaIds = Input.MateriaIds.Distinct().ToList();
        var materiasSeleccionadas = await context.Materia
            .Where(m => materiaIds.Contains(m.Id))
            .ToListAsync();

        if (materiasSeleccionadas.Count != materiaIds.Count)
        {
            ModelState.AddModelError("Input.MateriaIds", "Una de las materias seleccionadas no existe.");
        }

        if (!string.IsNullOrWhiteSpace(numeroPasaporte) &&
            await context.Pasaporte.AnyAsync(p => p.Numero == numeroPasaporte))
        {
            ModelState.AddModelError("Input.NumeroPasaporte", "Ya existe una persona con ese pasaporte.");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var persona = new Persona
        {
            Name = Input.Name.Trim(),
            dob = Input.FechaNacimiento!.Value,
            paisId = Input.PaisId,
            Pasaporte = new Pasaporte { Numero = numeroPasaporte },
            Materias = materiasSeleccionadas
        };

        context.Personas.Add(persona);
        await context.SaveChangesAsync();

        TempData["Mensaje"] = $"Se creó a {persona.Name} correctamente.";
        return RedirectToPage("Index");
    }

    private async Task LoadCatalogsAsync()
    {
        Paises = await context.Pais
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .Select(p => new SelectListItem(p.Name, p.Id.ToString()))
            .ToListAsync();

        Materias = await context.Materia
            .AsNoTracking()
            .OrderBy(m => m.Name)
            .ToListAsync();
    }
}
