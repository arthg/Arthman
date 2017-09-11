using Arthman.MongoDb;
using NUnit.Framework;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

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

            //TODO: determnie correct place for this bootstrapping
            BsonSerializer.RegisterSerializer(typeof(decimal), new DecimalSerializer(BsonType.Decimal128));
            BsonSerializer.RegisterSerializer(typeof(decimal?), new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Decimal128)));
        }

        [OneTimeTearDown]
        public void DropTestDatabase()
        {
            ArthmanContext.Database.Client.DropDatabase(_randomDatabaseName);
        }
    }
}
