using Arthman.Models;
using NUnit.Framework;

namespace Arthman.Tests.Integration.MongoDb
{
    [TestFixture]
    public class WeightsRepository : AbstractFixtureWithDatabase
    {
        //TODO: plenty.  all this proves at this point is the creation and drop of the test database
        [Test]
        public void Should_()
        {
            //arrange
            ///act
            //assert
            var collection = ArthmanContext.Database.GetCollection<WeightEntry>("weights");
            collection.InsertOne(new WeightEntry
            {
                Weight = 166.2m
            });
        }

    }
}
