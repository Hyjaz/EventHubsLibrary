namespace Library.EventHubs.Configuration
{
    public interface IEventHubsParameters : IConnectionString
    {
        string EventHubsConnectionString { get; }
    }
}