namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(params string[] messages) : base(default, false, messages)
        {
        }
    }
}