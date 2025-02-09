using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskService.Entites
{
    public class TaskComment
    {
        [BsonElement("userId")]
        [BsonRepresentation(BsonType.String)]
        public Guid UserId { get; set; } 

        [BsonElement("text")]
        public string Text { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

}
