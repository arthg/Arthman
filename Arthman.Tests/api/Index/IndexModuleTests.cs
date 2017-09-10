using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using SharpTestsEx;
using System.Threading.Tasks;
using Arthman.Tests.helpers;

namespace Arthman.Tests.api.Index
{
    [TestFixture]
    public abstract class IndexModuleTests
    {
        private Browser _browser;

        [SetUp]
        public void PrepareTestBrowser()
        {
            var defaultNancyBootstrapper = new DefaultNancyBootstrapper();
            _browser = new Browser(defaultNancyBootstrapper);
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
