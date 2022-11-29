using System;
using System.Runtime.Serialization;

namespace GameStore.CustomExceptions
{
    [Serializable]
    public class DoesNotExistException : CustomException
    {
        public DoesNotExistException(): base()
        {

        }

        public DoesNotExistException(string message) : base(message)
        {

        }
        protected DoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

    }
}
