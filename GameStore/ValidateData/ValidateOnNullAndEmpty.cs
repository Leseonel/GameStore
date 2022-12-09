using GameStore.CustomExceptions;

namespace GameStore.ValidateData
{
    public static class ValidateOnNullAndEmpty<T>
    {
        public static void ValidateDataOnNullAndEmpty(T input)
        {
            if (string.IsNullOrEmpty(input.ToString()))
            {
                throw new DoesNotExistsException();
            }
        }
    }
}
