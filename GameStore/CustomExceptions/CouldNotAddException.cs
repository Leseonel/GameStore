using System;
using System.Runtime.Serialization;

namespace GameStore.CustomExceptions
{
    [Serializable]
    public class CouldNotAddException : CustomException
    {
        public CouldNotAddException() : base()
        {

        }

        public CouldNotAddException(string message) : base(message)
        {

        }
        protected CouldNotAddException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
