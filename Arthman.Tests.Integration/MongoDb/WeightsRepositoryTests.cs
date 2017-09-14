using Arthman.Models;
using Arthman.MongoDb;
using Exceptionless;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Arthman.Tests.Integration.MongoDb
{
    [TestFixture]
    public class WeightsRepositoryTests : AbstractFixtureWithDatabase
    {
        private WeightsRepository _sut;

        [SetUp]
        public void PrepareWeightsRepositoryTests()
        {
            _sut = new WeightsRepository(ArthmanContext.Database);            
        }

        [Test]
        public async Task Should_insert_a_new_weight_entry()
        {
            //arrange

            //act
            var newId = await _sut.CreateAsync(new WeightEntry
            {
                Weight = RandomData.GetDecimal(0, int.MaxValue)
            });

            //assert
        }

    }
}
