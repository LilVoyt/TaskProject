using Contracts;
using MassTransit;
using MongoDB.Driver;
using TaskService.Data;
using TaskService.Entites;

namespace TaskService.Repositories
{
    public class TaskRepository
    {
        private readonly IMongoCollection<TaskEntity> _taskCollection;
        IRequestClient<UserExistingCheck> _client;
        public TaskRepository(MongoDBContext context, IRequestClient<UserExistingCheck> client)
        {
            _taskCollection = context.Database.GetCollection<TaskEntity>("tasks");
           _client = client;
        }

        public async Task<List<TaskEntity>> GetAllTasksAsync() =>
            await _taskCollection.Find(_ => true).ToListAsync();

        public async Task AddTaskAsync(TaskDto task)
        {
            TaskEntity taskEntity = new TaskEntity()
            {
                Id = Guid.NewGuid(),
                Title = task.title,
                Description = task.dectription,
                Status = task.taskStatus,
                Priority = task.taskPriority,
                AssignedTo = new List<Guid> { new Guid("9A0D6BDA-3D49-4E20-A8A0-5EA552C3F9B5") }
            };
            var res = await _client.GetResponse<UserExistingCheckResponse>(new UserExistingCheck() { Id = new Guid("9A1D6BDA-3D49-4E20-A8A0-5EA552C3F9B5") });

            if (res.Message.Exist)
            {
                await _taskCollection.InsertOneAsync(taskEntity);
            }
            else
            {
                throw new Exception("asd;lkfj");
            }
        }
            
    }

    public record TaskDto(string title, string? dectription, Entites.TaskStatus taskStatus, TaskPriority taskPriority);
}
