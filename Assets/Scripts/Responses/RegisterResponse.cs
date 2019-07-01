using Agate.GameServer.Models;
using Agate.Onyx.Core.Messages.Responses;
using System.Collections.Generic;

namespace Agate.GameServer.Responses
{
    /// <summary>
    /// Example Response Data
    /// </summary>
    public class RegisterResponse : BasicResponse
    {
        public User User { get; set; }
    }
}
