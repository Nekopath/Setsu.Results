using Setsu.Results.Errors;

namespace Setsu.Results.Tests
{
    public static class ResultTests
    {
        public class Ok
        {
            [Fact]
            public void IsSuccess_True()
            {
                var result = Result.Ok();
                Assert.True(result.IsSuccess);
            }
        }
        public class Fail
        {
            [Fact]
            public void IsFailure_String()
            {
                const string message = "Error";
                var result = Result.Fail(message);
                Assert.False(result.IsSuccess);
            }
            [Fact]
            public void IsFailure_GenericError()
            {
                const string message = "Error";
                var result = Result.Fail(new GenericError(message));
                Assert.False(result.IsSuccess);
            }

            [Fact]
            public void IsErrorType_String()
            {
                const string message = "Error";
                var result = Result.Fail(message);
                Assert.IsType<GenericError>(result.Error);
            }

            [Fact]
            public void IsErrorType_GenericError()
            {
                const string message = "Error";
                var result = Result.Fail(new GenericError(message));
                Assert.IsType<GenericError>(result.Error);
            }
        }
    }
}