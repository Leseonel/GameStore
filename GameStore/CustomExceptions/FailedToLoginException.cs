using System;
using System.Runtime.Serialization;

namespace GameStore.CustomExceptions
{
    [Serializable]
    public class FailedToLoginException : CustomException
    {
        public FailedToLoginException() : base()
        {

        }

        public FailedToLoginException(string message) : base(message)
        {

        }
        protected FailedToLoginException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
