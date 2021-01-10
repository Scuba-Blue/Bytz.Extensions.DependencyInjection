using System;

namespace Bitz.Extensions.DependencyInjection.Exceptions
{
    /// <summary>
    /// thrown when types registered to only an interface cannot be cast.
    /// </summary>
    public class OnlyInterfaceException
    : BitzExceptionBase
    {
        /// <summary>
        /// create with a message.
        /// </summary>
        /// <param name="message"></param>
        public OnlyInterfaceException
        (
            string message
        )
        : base(message)
        { }
    }
}