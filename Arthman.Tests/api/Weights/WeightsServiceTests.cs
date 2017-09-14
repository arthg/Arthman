using Arthman.api.Weights;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Arthman.Tests.api.Weights
{
    public abstract class WeightsServiceTests
    {
        private WeightsService _sut;

        [SetUp]
        public void PrepareWeightsServiceTests()
        {
            _sut = new WeightsService();
        }

        public sealed class AddWeightAsyncMethod : WeightsServiceTests
        {
            [Test]
            public async Task Should_call_the_repository_to_create_a_new_weigth_entry_and_return_the_identifier_Async()
            {
                //arrange
                var createWeightRequest = new CreateWeightRequest();

                //act
                var newId = await _sut.AddWeightAsync(createWeightRequest);

                //assert
                //TODO obviously a shitty impl 
                newId.Should().Be(string.Empty);
            }
        }
    }
}