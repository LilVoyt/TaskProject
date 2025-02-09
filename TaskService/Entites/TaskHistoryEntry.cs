using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskService.Entites
{
    public class TaskHistoryEntry
    {
        [BsonElement("userId")]
        [BsonRepresentation(BsonType.String)]
        public Guid UserId { get; set; }

        [BsonElement("change")]
        public string Change { get; set; } 

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

}
