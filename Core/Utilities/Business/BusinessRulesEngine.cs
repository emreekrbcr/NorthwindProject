using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public static class BusinessRulesEngine
    {
        /// <summary>
        /// This method controls business rules and if it occurs error in any rule, it returns these unsuccessful logic results.
        /// </summary>
        /// <param name="logics">Your business rules</param>
        /// <returns></returns>
        public static IResult Run(params IResult[] logics)
        {
            ErrorResult errorResult = new ErrorResult();

            foreach (var logic in logics)
            {
                if (logic.Success.Equals(false))
                {
                    errorResult.Messages.Add(logic.Messages[0]);
                }
            }

            if (errorResult.Messages.Count>0)
            {
                return errorResult; //Eğer iş kurallarından geçemezse ne kadar takıldığı iş kuralı varsa onların hepsini bizim hata mesajında yollayacak
            }

            return new SuccessResult();
        }

        /// <summary>
        /// This method controls business rules and if it occurs error in any rule, it returns these unsuccessful logic results.
        /// </summary>
        /// <param name="logics">Your business rules</param>
        /// <returns></returns>
        public static IDataResult<T> Run<T>(params IResult[] logics)
        {
            ErrorDataResult<T> errorDataResult = new ErrorDataResult<T>();

            foreach (var logic in logics)
            {
                if (logic.Success.Equals(false))
                {
                    errorDataResult.Messages.Add(logic.Messages[0]);
                }
            }

            if (errorDataResult.Messages.Count>0)
            {
                return errorDataResult;
            }

            return new SuccessDataResult<T>();
        }
    }
}
