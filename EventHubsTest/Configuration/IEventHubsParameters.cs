namespace EventHubsTest.Configuration
{
    public interface IEventHubsParameters : IConnectionString
    {
        string EventHubsConnectionString { get; }
    }
}