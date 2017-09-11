using Arthman.Models;
using NUnit.Framework;

namespace Arthman.Tests.Integration.MongoDb
{
    [TestFixture]
    public class WeightsRepository : AbstractFixtureWithDatabase
    {
        [Test]
        public void Should_()
        {
            var collection = ArthmanContext.Database.GetCollection<WeightEntry>("weights");
            collection.InsertOne(new WeightEntry
            {
                Weight = 166.2m
            });
        }

    }
}
