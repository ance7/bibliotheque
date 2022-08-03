using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bibliotheque.Data;
using Bibliotheque.Models;

namespace Bibliotheque.Pages.Livres
{
    public class DetailsModel : PageModel
    {
        private readonly Bibliotheque.Data.LivreContext _context;

        public DetailsModel(Bibliotheque.Data.LivreContext context)
        {
            _context = context;
        }

      public Livre Livre { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Livre == null)
            {
                return NotFound();
            }

            var livre = await _context.Livre.FirstOrDefaultAsync(m => m.id == id);
            if (livre == null)
            {
                return NotFound();
            }
            else 
            {
                Livre = livre;
            }
            return Page();
        }
    }
}
