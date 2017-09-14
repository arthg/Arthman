using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EventStore.ClientAPI;

namespace Arthman.EventStore
{
    public sealed class EventStore : IEventStore
    {
        /*
         * This class based on sample code from 
         * microservices-in-dotnetcore
         */
        //TODO: connection string from config - environment variable??
        private const string connectionString = "ConnectTo=tcp://admin:changeit@127.0.0.1:1113";
        private IEventStoreConnection connection = EventStoreConnection.Create(connectionString);

        //TODO: unit tests, finish integration test(s)
        public async Task Raise(string eventName, object content)
        {
            await connection.ConnectAsync().ConfigureAwait(false);
            var contentJson = JsonConvert.SerializeObject(content);
            // TODO: probably want UTC
            var metaDataJson =
              JsonConvert.SerializeObject(new EventMetadata
              {
                  OccurredAt = DateTimeOffset.Now,
                  EventName = eventName
              });

            var eventData = new EventData(
              Guid.NewGuid(),
              "ShoppingCartEvent",
              isJson: true,
              data: Encoding.UTF8.GetBytes(contentJson),
              metadata: Encoding.UTF8.GetBytes(metaDataJson)
            );

            //TODO: get rid of hard-coded stream name - either pass as parameter or have a class instance
            //TODO: similar for event type above 
            await
              connection.AppendToStreamAsync(
                "ShoppingCart",
                ExpectedVersion.Any,
                 eventData);
        }

        private class EventMetadata
        {
            public DateTimeOffset OccurredAt { get; set; }
            public string EventName { get; set; }
        }
    }
}
