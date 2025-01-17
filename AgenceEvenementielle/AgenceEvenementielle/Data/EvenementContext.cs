using AgenceEvenementielle.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenceEvenementielle.Data
{
    public class EvenementContext : DbContext
    {
        public DbSet<Evenement> Evenements { get; set; }
        //public DbSet<Participant> Participants { get; set; }
        public List<Participant> Participants { get; } = new List<Participant>();
        public DbSet<Statistique> Statistiques { get; set; }

      

        public EvenementContext(DbContextOptions options) : base(options) {
            Participant JMARTIN = new Participant { Id = 1, Nom = "MARTIN", Prenom = "Jean-Pierre" };
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        //LINQ
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evenement>().HasKey(evenement => evenement.Id);
            modelBuilder.Entity<Evenement>().Property(evenement => evenement.Nom).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Evenement>().Property(evenement => evenement.Lieu).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Evenement>().Property(evenement => evenement.Date).IsRequired();
            modelBuilder.Entity<Evenement>().Property(evenement => evenement.Horraire).IsRequired().HasMaxLength(20);

            modelBuilder.Entity<Participant>().Property(participant => participant.Nom).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Participant>().Property(participant => participant.Prenom).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Participant>().HasMany<Evenement>(participant => participant.Evenements)
                                              .WithMany(evenement => evenement.Participants);

        }
        public DbSet<AgenceEvenementielle.Models.Participant> Participant { get; set; } = default!;

    }
}
