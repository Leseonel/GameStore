using System;
using System.Runtime.Serialization;

namespace GameStore.CustomExceptions
{
    [Serializable]
    public class AlreadyExistException : CustomException
    {
        public AlreadyExistException() : base()
        {

        }

        public AlreadyExistException(string message) : base(message)
        {

        }
        protected AlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

    }
}