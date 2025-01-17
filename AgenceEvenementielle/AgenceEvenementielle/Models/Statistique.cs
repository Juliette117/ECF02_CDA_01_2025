using MongoDB.Bson.Serialization.Attributes;

namespace AgenceEvenementielle.Models
{
    public class Statistique
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("periode")]
        public string Periode { get; set; }

        [BsonElement("inscription")] 
        public string NbInscription { get; set; }

    }
}
