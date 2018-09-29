using Microsoft.Azure.EventHubs;

namespace EventHubsTest.Configuration
{
    public class EventHubsParameters : IEventHubsParameters
    {
        public EventHubsParameters(string connectionString, string name)
        {
            ConnectionString = connectionString;
            Name = name;
            EventHubsConnectionString = new EventHubsConnectionStringBuilder(ConnectionString)
            {
                EntityPath = Name
            }.ToString();
        }

        public string EventHubsConnectionString { get; }
        public string ConnectionString { get; }
        public string Name { get; }
    }
}