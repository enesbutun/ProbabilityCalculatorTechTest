namespace ProbabilityCalculatorAPI.Exceptions
{
    public class UnsupportedOperationException : Exception
    {
        public UnsupportedOperationException(string operation)
            : base($"The operation '{operation}' is not supported.")
        {
        }
    }
}
