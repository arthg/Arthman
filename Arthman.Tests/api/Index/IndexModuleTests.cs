using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using SharpTestsEx;
using System.Threading.Tasks;
using Arthman.api.Index;

namespace Arthman.Tests.api.Index
{
    [TestFixture]
    public abstract class IndexModuleTests
    {
        private Browser _browser;

        [SetUp]
        public void PrepareTestBrowser()
        {
             _browser = new Browser(with =>
            {
                with.Module<IndexModule>();
            });
        }

        public sealed class IndexGetEndpoint : IndexModuleTests
        {
            [Test]
            public async Task Should_return_status_code_ok_Async()
            {
                //arrange

                //act
                var result = await _browser.Get("/");

                //assert
                result.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}
