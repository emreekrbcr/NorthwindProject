using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }
        List<string> Messages { get; }
    }
}