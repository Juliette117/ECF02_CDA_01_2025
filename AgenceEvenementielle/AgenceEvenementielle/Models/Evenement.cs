using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgenceEvenementielle.Models
{
    public class Evenement
    {
       public int Id { get; set; }
        public string Nom {  get; set; }
        public string Lieu { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Horraire { get; set; }

        public List<Participant> Participants { get; set; } = new List<Participant>();
        


    }
}
