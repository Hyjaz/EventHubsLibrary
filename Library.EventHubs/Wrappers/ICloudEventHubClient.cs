using System.Collections.Generic;
using System.Threading.Tasks;
using Library.EventHubs.Messages;

namespace Library.EventHubs.Wrappers
{
    public interface ICloudEventHubClient
    {
        Task SendMessage(IList<IMessage> messageList);

    }
}