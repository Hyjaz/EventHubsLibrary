using System.Text;
using Library.EventHubs.Messages;
using Newtonsoft.Json;

namespace Library.EventHubs.Serializer
{
    public class PayloadSerializer : IPayloadSerializer
    {
        public byte[] Serialize(IMessage message)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
        }

        public IMessage Deserialize(string message)
        {
            return JsonConvert.DeserializeObject<IMessage>(message);
        }
    }
}