using System;
using System.Runtime.Serialization;

namespace GameStore.CustomExceptions
{
    [Serializable]
    public class DoesNotExistsException : CustomException
    {
        public DoesNotExistsException(): base()
        {

        }

        public DoesNotExistsException(string message) : base(message)
        {

        }
        protected DoesNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

    }
}
