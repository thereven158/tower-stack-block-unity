using Agate.Onyx.Core.Messages;

namespace Agate.GameServer.Messages
{
    /*
     * This Class must be extended by all other message class that
     * want to be Controller parameter
     */ 

    /// <summary>
    /// Basic message that need to be assigned for all API message model
    /// </summary>
    public class ClientMessage : AgateMessage
    {

        public string DeviceId { get; set; }

    }
}
