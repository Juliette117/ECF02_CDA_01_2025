namespace AgenceEvenementielle.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public List<Evenement> Evenements { get; set; } = new List<Evenement>();

    }
}
