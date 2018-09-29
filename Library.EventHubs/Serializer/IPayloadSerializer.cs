using Library.EventHubs.Messages;

namespace Library.EventHubs.Serializer
{
    public interface IPayloadSerializer
    {
        byte[] Serialize(IMessage message);
        IMessage Deserialize(string messageAsString);
    }
}