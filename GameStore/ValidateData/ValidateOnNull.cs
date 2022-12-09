using GameStore.CustomExceptions;

namespace GameStore.ValidateData
{
    public static class ValidateOnNull<T>
    {
        public static void ValidateDataOnNull(T input)
        {
            if (input == null)
            {
                throw new DoesNotExistsException();
            }
        }
    }
}
