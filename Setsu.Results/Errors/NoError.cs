namespace Setsu.Results.Errors
{
    public sealed class NoError : IError
    {
        public string Message { get => "No error was specified. This occurs when the parameterless constructor of the Result<T> type is called."; }
    }
}
