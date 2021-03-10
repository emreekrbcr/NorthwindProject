using System.Collections.Generic;
using System.Linq;

namespace Core.Utilities.Results
{
    public abstract class Result:IResult
    {
        public bool Success { get; }
        public List<string> Messages { get; }

        protected Result(bool success, params string[] messages)
        {
            Success = success;
            Messages = messages.ToList();
        }

        protected Result(bool success)
        {
            Success = success;
        }
    }
}