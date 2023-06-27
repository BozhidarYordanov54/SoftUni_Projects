using System;

namespace LogForU.Core.Exceptions
{
    public class EmptyFileExtensionException : Exception
    {
        private const string DefaultMessage =
            "File extension cannot be null or empty";

        public EmptyFileExtensionException()
            : base(DefaultMessage)
        {

        }

        public EmptyFileExtensionException(string message)
            : base(message)
        {

        }
    }
}
