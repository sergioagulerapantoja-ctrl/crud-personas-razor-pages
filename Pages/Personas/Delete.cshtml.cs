using _2026web3.Data;
using _2026web3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _2026web3.Pages.Personas;

public class DeleteModel(ApplicationDbContext context) : PageModel
{
    public Persona Persona { get; private set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var persona = await FindPersonaAsync(id);
        if (persona is null)
        {
            return NotFound();
        }

        Persona = persona;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var persona = await context.Personas.FindAsync(id);
        if (persona is null)
        {
            return NotFound();
        }

        context.Personas.Remove(persona);
        await context.SaveChangesAsync();

        TempData["Mensaje"] = $"Se eliminó a {persona.Name} correctamente.";
        return RedirectToPage("Index");
    }

    private Task<Persona?> FindPersonaAsync(int id) => context.Personas
        .AsNoTracking()
        .Include(p => p.Pais)
        .Include(p => p.Pasaporte)
        .SingleOrDefaultAsync(p => p.Id == id);
}
