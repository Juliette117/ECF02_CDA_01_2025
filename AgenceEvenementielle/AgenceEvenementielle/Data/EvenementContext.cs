using AgenceEvenementielle.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenceEvenementielle.Data
{
    public class EvenementContext : DbContext
    {
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public DbSet<Statistique> Statistiques { get; set; }

        public EvenementContext(DbContextOptions options) : base(options) { }

    }
}
