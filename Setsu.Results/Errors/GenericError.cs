namespace Setsu.Results.Errors
{
    public sealed class GenericError(string message) : IError
    {
        public string Message { get; } = message;
    }
}
