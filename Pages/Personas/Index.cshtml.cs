using _2026web3.Data;
using _2026web3.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _2026web3.Pages.Personas;

public class IndexModel(ApplicationDbContext context) : PageModel
{
    public IReadOnlyList<Persona> Personas { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Personas = await context.Personas
            .AsNoTracking()
            .Include(p => p.Pais)
            .Include(p => p.Pasaporte)
            .Include(p => p.Materias)
            .OrderBy(p => p.Name)
            .ToListAsync();
    }
}
