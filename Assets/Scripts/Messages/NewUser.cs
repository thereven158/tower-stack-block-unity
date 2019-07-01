using Agate.GameServer.Models;

namespace Agate.GameServer.Messages
{
    public class NewUser : ClientMessage
    {
        public User User { get; set; }
        public int Timer { get; set; }
    }
}
