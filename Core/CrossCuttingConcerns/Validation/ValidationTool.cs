using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static class FluentValidation
        {
            public static void Validate(IValidator validator, object entity)
            {
                var context = new ValidationContext<object>(entity);
                var validationResult = validator.Validate(context);

                if (validationResult.IsValid.Equals(false))
                {
                    throw new ValidationException(validationResult.Errors);
                }
            }
        }
    }
}