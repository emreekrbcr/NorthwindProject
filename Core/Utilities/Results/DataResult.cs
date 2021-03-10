namespace Core.Utilities.Results
{
    public abstract class DataResult<T>:Result,IDataResult<T>
    {
        public T Data { get; }

        protected DataResult(T data, bool success, params string[] messages) : base(success, messages)
        {
            Data = data;
        }

        protected DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
    }
}
