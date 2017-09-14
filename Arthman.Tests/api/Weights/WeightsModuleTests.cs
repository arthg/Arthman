using Arthman.api.Common;
using Arthman.api.Weights;
using Arthman.Tests.helpers;
using Exceptionless;
using FluentAssertions;
using Moq;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Arthman.Tests.api.Weights
{
    [TestFixture]
    public abstract class WeightsModuleTests
    {
        private Mock<IWeightsService> _weightsService;
        private Browser Browser { get; set; }

        [SetUp]
        public void PrepareWeightsModuleTests()
        {
            _weightsService = new Mock<IWeightsService>(MockBehavior.Strict);

            Browser = new Browser(with => {
                with.Module<WeightsModule>();
                with.Dependency<IWeightsService>(_weightsService.Object);
                // TODO: missing dependencies when comment removed - we need this for ease of testing response bodies
               // with.ResponseProcessor<TestResponseInterceptorProcessor>();
        });
        }

        public sealed class PostEndpoint : WeightsModuleTests
        {
            [Test]
            public async Task Should_return_status_code_201_for_the_created_weight_entry_Async()
            {
                //arrange
                //TODO: this will change with intro of mapper...

                var weight = RandomData.GetDecimal(0, int.MaxValue);
                var createWeightRequestDto = new CreateWeightRequestDto
                {
                    Weight = weight.ToString()
                };

                var newId = RandomData.GetAlphaString();
                _weightsService
                    .Setup(s => s.AddWeightAsync(It.Is<CreateWeightRequest>(r => r.Weight == weight)))
                    .ReturnsAsync(newId);

                //act
                //TODO: the Accept should not be necessary
                var response = await Browser.Post(RootUriStrings.Weights, 
                    with => with.JsonBrowserContext(createWeightRequestDto)
                                .Accept("application/json"));

                //assert
                //TODO: assert on Location header
                //TODO: assert the Id is on the response body
                response.StatusCode
                        .Should().Be(HttpStatusCode.Created);
            }
        }
    }
}
