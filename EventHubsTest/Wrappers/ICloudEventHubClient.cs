using System.Collections.Generic;
using System.Threading.Tasks;
using EventHubsTest.Messages;

namespace EventHubsTest.Wrappers
{
    public interface ICloudEventHubClient
    {
        Task SendMessage(IList<IMessage> messageList);

    }
}