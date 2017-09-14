using Arthman.EventStore;
using Exceptionless;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Arthman.Tests.EventStore
{
    [TestFixture]
    public abstract class EventStoreTests
    {
        private sealed class TestContent
        {
            public string Property1 { get; set; }
            public string Property2 { get; set; }
        }

        private IEventStore _sut;
        private string _eventName;
        private TestContent _testContent;

        [SetUp]
        public void PrepareEventStoreTests()
        {
            _eventName = RandomData.GetString(10, 10);
            _testContent = new TestContent
            {
                Property1 = RandomData.GetString(10, 10),
                Property2 = RandomData.GetString(10, 10)
            };
            _sut = new Arthman.EventStore.EventStore();
        }

        public sealed class RaiseMethod : EventStoreTests
        {
            [Test]
            public async Task Should_raise_the_event_Async()
            {
                //arrange

                //act
                await _sut.Raise(_eventName, _testContent);

                //assert
                //TODO: query the event store for the event
            }
        }
    }
}
