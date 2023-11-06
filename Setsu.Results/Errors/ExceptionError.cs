using System;

namespace Setsu.Results.Errors
{
    public sealed class ExceptionError(Exception ex) : IError
    {
        public Exception Exception { get; } = ex;
        public string Message { get => Exception.Message; }
    }
}
