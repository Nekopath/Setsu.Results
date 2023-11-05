using Setsu.Results.Errors;
using System;

namespace Setsu.Results
{
    public readonly struct Result
    {
        public readonly bool IsSuccess;
        private readonly IError? _error;
        public IError Error
        {
            get
            {
                if (IsSuccess)
                    throw new InvalidOperationException("This result is not in a failed state.");
                return _error!;
            }
        }

        public Result()
        {
            IsSuccess = true;
            _error = null;
        }
        public Result(IError error)
        {
            IsSuccess = false;
            _error = error ?? throw new ArgumentNullException(nameof(error));
        }

        public static Result Ok()
        {
            return new();
        }
        public static Result<T> Ok<T>(T result) where T: notnull
        {
            return new(result);
        }
        public static Result Fail(IError error)
        {
            return new(error);
        }
        public static Result Fail(string message)
        {
            return new(new GenericError(message));
        }
        public static Result<T> Fail<T>(IError error) where T : notnull
        {
            return new(error);
        }
        public static Result<T> Fail<T>(string message) where T : notnull
        {
            return new(new GenericError(message));
        }
    }

    public readonly struct Result<T> where T: notnull
    {
        public readonly bool IsSuccess;
        private readonly IError? _error;
        public IError Error
        {
            get
            {
                if (IsSuccess)
                    throw new InvalidOperationException("This result is not in a failed state.");
                return _error!;
            }
        }
        private readonly T? _result;
        public T Value
        {
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException("This result is not in a success state.");
                return _result!;
            }
        }

        public Result()
        {
            IsSuccess = false;
            _error = new NoError();
            _result = default;
        }
        public Result(IError error)
        {
            IsSuccess = false;
            _error = error ?? throw new ArgumentNullException(nameof(error));
            _result = default;
        }
        public Result(T value)
        {
            IsSuccess = true;
            _error = null;
            _result = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static implicit operator Result<T>(Result value)
        {
            if (value.IsSuccess)
                return new(value.Error);
            throw new InvalidOperationException("Cannot convert successful non-generic Result value to Result<T> value.");
        }
    }
}
