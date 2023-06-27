using System;

namespace LogForU.Core.Exceptions
{
    public class EmptyCreateTimeException : Exception
    {
        private const string DefaultMessage =
            "Created time of message cannot be null or whitespace";
        public EmptyCreateTimeException()
            : base(DefaultMessage)
        {
        }
        public EmptyCreateTimeException(string message)
            : base(message)
        {

        }
    }
}
