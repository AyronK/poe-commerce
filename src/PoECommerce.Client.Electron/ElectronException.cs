using System;
using System.Runtime.Serialization;

namespace PoECommerce.Client.Electron
{
    public class ElectronException : Exception
    {
        public ElectronException()
        {
        }

        protected ElectronException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ElectronException(string message) : base(message)
        {
        }

        public ElectronException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}