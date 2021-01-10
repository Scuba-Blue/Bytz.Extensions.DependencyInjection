using System;

namespace Bitz.Extensions.DependencyInjection.Exceptions
{
    /// <summary>
    /// basis for bitz exceptions.
    /// </summary>
    public abstract class BitzExceptionBase : Exception
    {
        /// <summary>
        /// must be constructred with a message.
        /// </summary>
        /// <param name="message">exception message.</param>
        public BitzExceptionBase(string message)
        : base(message)
        { }
    }
}