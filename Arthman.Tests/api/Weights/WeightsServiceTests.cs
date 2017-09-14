using Arthman.api.Weights;
using Arthman.Models;
using Arthman.MongoDb;
using Exceptionless;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Arthman.Tests.api.Weights
{
    public abstract class WeightsServiceTests
    {
        private Mock<IWeightsRepository> _weightsRepository;

        private WeightsService _sut;

        [SetUp]
        public void PrepareWeightsServiceTests()
        {
            _weightsRepository = new Mock<IWeightsRepository>(MockBehavior.Strict);
            _sut = new WeightsService(_weightsRepository.Object);
        }

        public sealed class AddWeightAsyncMethod : WeightsServiceTests
        {
            [Test]
            public async Task Should_call_the_repository_to_create_a_new_weight_entry_and_return_the_identifier_Async()
            {
                //arrange
                var createWeightRequest = new CreateWeightRequest
                {
                    Weight = RandomData.GetDecimal()
                };

                var newId = RandomData.GetString(10, 10);
                _weightsRepository
                    .Setup(r => r.CreateAsync(It.Is<WeightEntry>(w => w.Weight == createWeightRequest.Weight)))
                    .ReturnsAsync(newId);

                //act
                var createdId = await _sut.AddWeightAsync(createWeightRequest);

                //assert
                createdId.Should().Be(newId);
            }
        }
    }
}