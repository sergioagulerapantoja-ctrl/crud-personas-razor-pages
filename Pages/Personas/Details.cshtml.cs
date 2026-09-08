using _2026web3.Data;
using _2026web3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _2026web3.Pages.Personas;

public class DetailsModel(ApplicationDbContext context) : PageModel
{
    public Persona Persona { get; private set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var persona = await context.Personas
            .AsNoTracking()
            .Include(p => p.Pais)
            .Include(p => p.Pasaporte)
            .Include(p => p.Materias)
            .SingleOrDefaultAsync(p => p.Id == id);

        if (persona is null)
        {
            return NotFound();
        }

        Persona = persona;
        return Page();
    }
}
