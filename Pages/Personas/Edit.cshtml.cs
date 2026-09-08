using _2026web3.Data;
using _2026web3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _2026web3.Pages.Personas;

public class EditModel(ApplicationDbContext context) : PageModel
{
    [BindProperty]
    public PersonaInputModel Input { get; set; } = new();

    public IReadOnlyList<SelectListItem> Paises { get; private set; } = [];
    public IReadOnlyList<Materia> Materias { get; private set; } = [];

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var persona = await context.Personas
            .AsNoTracking()
            .Include(p => p.Pasaporte)
            .Include(p => p.Materias)
            .SingleOrDefaultAsync(p => p.Id == id);

        if (persona is null)
        {
            return NotFound();
        }

        Input = new PersonaInputModel
        {
            Name = persona.Name,
            FechaNacimiento = persona.dob,
            PaisId = persona.paisId,
            NumeroPasaporte = persona.Pasaporte?.Numero ?? string.Empty,
            MateriaIds = persona.Materias.Select(m => m.Id).ToList()
        };

        await LoadCatalogsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        await LoadCatalogsAsync();
        var persona = await context.Personas
            .Include(p => p.Pasaporte)
            .Include(p => p.Materias)
            .SingleOrDefaultAsync(p => p.Id == id);

        if (persona is null)
        {
            return NotFound();
        }

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
            await context.Pasaporte.AnyAsync(p => p.Numero == numeroPasaporte && p.personaId != id))
        {
            ModelState.AddModelError("Input.NumeroPasaporte", "Ya existe una persona con ese pasaporte.");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        persona.Name = Input.Name.Trim();
        persona.dob = Input.FechaNacimiento!.Value;
        persona.paisId = Input.PaisId;

        if (persona.Pasaporte is null)
        {
            persona.Pasaporte = new Pasaporte { Numero = numeroPasaporte };
        }
        else
        {
            persona.Pasaporte.Numero = numeroPasaporte;
        }

        persona.Materias.Clear();
        foreach (var materia in materiasSeleccionadas)
        {
            persona.Materias.Add(materia);
        }

        await context.SaveChangesAsync();
        TempData["Mensaje"] = $"Se actualizó a {persona.Name} correctamente.";
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
