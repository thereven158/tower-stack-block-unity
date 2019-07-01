using Agate.GameServer.Models;

namespace Agate.GameServer.Responses
{
    /*
     * This Class must be extended by all other response class that
     * want to be Controller response body
     */

    /// <summary>
    /// Basic response that need to be inherited for all API response model
    /// </summary>
    public class BasicResponse
    {
        /// <summary>
        /// Gets of sets the error data of the response
        /// </summary>
        /// <value>The error detail if error occured, null if not</value>
        public Error Error { get; set; } = null;

        /// <summary>
        /// Additional information of the request result
        /// </summary>
        public string Message { get; set; } = "ok";
    }
}
