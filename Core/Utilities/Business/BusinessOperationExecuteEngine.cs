using System;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessOperationExecuteEngine
    {
        public static IResult Run(Action dalOperation, string successMessage, string errorMessage)
        {
            try
            {
                dalOperation.Invoke();
                return new SuccessResult(successMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(errorMessage);
            }
        }

        public static IDataResult<T> Run<T>(Func<T> dalOperation, string successMessage, string errorMessage)
        {
            var data = dalOperation.Invoke();

            if (data == null)
            {
                return new ErrorDataResult<T>(errorMessage);
            }

            return new SuccessDataResult<T>(data, successMessage);
        }
    }
}
