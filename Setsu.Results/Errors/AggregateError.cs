using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Setsu.Results.Errors
{
    public sealed class AggregateError(IError[] errors, string message) : IError
    {
        public AggregateError(params IError[] errors) : this(errors, BuildMessage(errors)) { }
        public IError[] Errors { get; } = errors;
        public string Message { get => message; }

        private static string BuildMessage(IError[] errors)
        {
            var sb = new StringBuilder("An aggregate error occurred.");
            sb.AppendLine();
            foreach (var error in errors)
            {
                sb.AppendLine("- " + error.Message);
            }
            return sb.ToString();
        }
    }
}
