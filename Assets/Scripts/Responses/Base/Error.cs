namespace Agate.GameServer.Models
{
    /// <summary>
    /// Generic Error Model used in all controller
    /// </summary>
    public class Error
    {
        /// <summary>
        /// A human-readable representation of the error.
        /// </summary>
        public string Code;

        /// <summary>
        /// One of a server-defined set of error codes
        /// </summary>
        public string Id;

        /// <summary>
        /// The target of the error.
        /// </summary>
        public string Target;

        /// <summary>
        /// An array of details about specific errors that led to this reported error.
        /// </summary>
        public object[] details;

    }
}
