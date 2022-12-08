using System;
using System.Runtime.Serialization;

namespace GameStore.CustomExceptions
{
    [Serializable]
    public class AlreadyExistsException : CustomException
    {
        public AlreadyExistsException() : base()
        {

        }

        public AlreadyExistsException(string message) : base(message)
        {

        }
        protected AlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

    }
}