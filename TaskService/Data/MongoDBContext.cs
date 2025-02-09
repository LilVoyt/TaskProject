using MongoDB.Driver;

namespace TaskService.Data
{
    public class MongoDBContext
    {
        public IMongoDatabase Database { get; }

        public MongoDBContext(IConfiguration configuration, IMongoClient mongoClient)
        {
            var databaseName = configuration["MongoDB:DatabaseName"];
            Database = mongoClient.GetDatabase(databaseName);
        }
    }
}
