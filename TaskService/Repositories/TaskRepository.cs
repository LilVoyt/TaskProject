using MongoDB.Driver;
using TaskService.Data;
using TaskService.Entites;

namespace TaskService.Repositories
{
    public class TaskRepository
    {
        private readonly IMongoCollection<TaskEntity> _taskCollection;

        public TaskRepository(MongoDBContext context)
        {
            _taskCollection = context.Database.GetCollection<TaskEntity>("tasks");
        }

        public async Task<List<TaskEntity>> GetAllTasksAsync() =>
            await _taskCollection.Find(_ => true).ToListAsync();

        public async Task AddTaskAsync(TaskEntity task) =>
            await _taskCollection.InsertOneAsync(task);
    }
}
