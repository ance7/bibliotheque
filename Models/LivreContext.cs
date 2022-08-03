using Microsoft.EntityFrameworkCore;
using Bibliotheque.Models;


namespace Bibliotheque.Data
{
    public class LivreContext:DbContext
    {
        public LivreContext (DbContextOptions<LivreContext> option):base(option){}
        public DbSet<Livre> Livre => Set<Livre>();
    }
}




