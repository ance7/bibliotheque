using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bibliotheque.Data;
using Bibliotheque.Models;

namespace Bibliotheque.Pages.Livres
{
    public class CreateModel : PageModel
    {
        private readonly Bibliotheque.Data.LivreContext _context;

        public CreateModel(Bibliotheque.Data.LivreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Livre Livre { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Livre == null || Livre == null)
            {
                return Page();
            }

            _context.Livre.Add(Livre);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
