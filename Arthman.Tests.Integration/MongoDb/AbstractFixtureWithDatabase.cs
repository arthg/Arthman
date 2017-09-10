using Arthman.MongoDb;
using NUnit.Framework;
using MongoDB.Driver;

namespace Arthman.Tests.Integration.MongoDb
{
    [TestFixture]
    public abstract class AbstractFixtureWithDatabase
    {
        protected ArthmanContext ArthmanContext { get; private set; }
        private string _randomDatabaseName;

        [OneTimeSetUp]
        public void PrepareTestDatabase()
        {
            // TODO from config
            var connectionString = "mongodb://localhost/ArthMan";
            var mongoUri = MongoUrl.Create(connectionString);

            _randomDatabaseName = "Test" + Exceptionless.RandomData.GetString(8,8);
            var randomConnectionString = "mongodb://" + mongoUri.Server;

            ArthmanContext = new ArthmanContext(randomConnectionString, _randomDatabaseName);
        }

        [OneTimeTearDown]
        public void DropTestDatabase()
        {
            ArthmanContext.Database.Client.DropDatabase(_randomDatabaseName);
        }
    }
}
