using GameStore.CustomExceptions;
using System.Collections.Generic;

namespace GameStore.ValidateData
{
    public static class ValidateOnCountZero<T>
    {
        public static void ValidateDataOnCountZero(List<T> input)
        {
            if (input.Count == 0)
            {
                throw new DoesNotExistsException();
            }
        }
    }
}
