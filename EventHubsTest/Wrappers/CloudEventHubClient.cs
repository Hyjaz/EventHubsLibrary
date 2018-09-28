using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventHubsTest.Configuration;
using EventHubsTest.Messages;
using EventHubsTest.Serializer;
using Microsoft.Azure.EventHubs;

namespace EventHubsTest.Wrappers
{
    public class CloudEventHubClient : ICloudEventHubClient
    {
        public IEventHubsParameters EventHubsParameters { get; }
        public EventHubClient EventHubClient { get; }
        public IPayloadSerializer PayloadSerializer { get; }
        public CloudEventHubClient(IEventHubsParameters eventHubParameters, IPayloadSerializer payloadSerializer)
        {
            EventHubsParameters = eventHubParameters;
            EventHubClient = EventHubClient.CreateFromConnectionString(eventHubParameters.EventHubsConnectionString);
            PayloadSerializer = payloadSerializer;
        }

        public async Task SendMessage(IList<IMessage> messageList)
        {
            IList<Task> taskList = new List<Task>();
            foreach (var message in messageList)
            {
                var dataAsBytes = PayloadSerializer.Serialize(message);
                var eventData = new EventData(dataAsBytes);
                taskList.Add(EventHubClient.SendAsync(eventData));
            }
            try
            {
                await Task.WhenAll(taskList.ToArray());
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}