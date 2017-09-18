using MongoDB.Driver;

namespace Arthman.MongoDb
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }

    public class ArthmanContext : IMongoContext
    {
        private readonly IMongoDatabase _database;

        /*
        public ArthmanContext(string connectionString, string databaseName)
        {
            //TODO: later from Env var
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
        */
        public ArthmanContext()
        {
            var client = new MongoClient("mongodb://localhost/");
            _database = client.GetDatabase("ArthMan");
        }

        public IMongoDatabase Database { get { return _database; } }
    }
}
