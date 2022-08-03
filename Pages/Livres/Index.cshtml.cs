using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bibliotheque.Data;
using Bibliotheque.Models;

namespace Bibliotheque.Pages.Livres
{
    public class IndexModel : PageModel
    {
        private readonly Bibliotheque.Data.LivreContext _context;

        public IndexModel(Bibliotheque.Data.LivreContext context)
        {
            _context = context;
        }

        public IList<Livre> Livre { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        // The list of genres
        public SelectList Genres { get; set; }

        // The select genre
        [BindProperty(SupportsGet = true)]
        public string GenreLivre { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Livre orderby m.genre select m.genre;
            var livres = from m in _context.Livre select m;
            
            if (!string.IsNullOrEmpty(SearchString))
            {
                
                livres = livres.Where(s => s.titre.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(GenreLivre))
            {
                livres = livres.Where(x => x.genre == GenreLivre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Livre = await livres.ToListAsync();
            
        }
    }
}
