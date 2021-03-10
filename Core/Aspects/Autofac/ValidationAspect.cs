using System;
using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac
{
    public class ValidationAspect : MethodInterceptor
    {
        private readonly Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (typeof(IValidator).IsAssignableFrom(validatorType).Equals(false))
            {
                throw new Exception(
                    "Parametre olarak IValidator'dan türeyen bir doğrulama sınıfı girilmelidir."); //WrongValidationType
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation) //invocation'ı metod olarak düşünebiliriz
        {
            IValidator validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //Örneğin ProductValidator vardı bizim. Onun BaseType'ı AbstractValidator<Product> idi. Onun Generic argümanlarını al. Sadece Product var ve onu istiyoruz. O yüzden 0.indisdeki Product tipini döndürür.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //Metodun parametrelerini alıyor

            foreach (var entity in entities)
            {
                ValidationTool.FluentValidation.Validate(validator,entity);
            }
        }
    }
}
