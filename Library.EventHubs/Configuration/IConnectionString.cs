namespace EventHubsTest.Configuration
{
    public interface IConnectionString
    {
        string ConnectionString { get; }
        string Name { get; }
    }
}