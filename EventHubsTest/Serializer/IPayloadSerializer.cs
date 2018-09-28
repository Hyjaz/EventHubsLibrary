using EventHubsTest.Messages;

namespace EventHubsTest.Serializer
{
    public interface IPayloadSerializer
    {
        byte[] Serialize(IMessage message);
        IMessage Deserialize(string messageAsString);
    }
}