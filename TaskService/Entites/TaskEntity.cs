using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TaskService.Entites
{
    public class TaskEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonElement("status")]
        public TaskStatus Status { get; set; } = TaskStatus.Pending;

        [BsonElement("priority")]
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        [BsonElement("tags")]
        public List<string> Tags { get; set; } = new();

        [BsonElement("assignedTo")]
        [BsonRepresentation(BsonType.String)]
        public List<Guid> AssignedTo { get; set; } = new();

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [BsonElement("deadline")]
        public DateTime? Deadline { get; set; }

        [BsonElement("comments")]
        public List<TaskComment> Comments { get; set; } = new();

        [BsonElement("history")]
        public List<TaskHistoryEntry> History { get; set; } = new();

    }
}
