namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(params string[] messages) : base(false, messages)
        {
        }
    }
}