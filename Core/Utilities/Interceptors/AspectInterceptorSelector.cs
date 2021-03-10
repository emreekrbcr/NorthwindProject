using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors) //bu metod zaten IInterceptorSelector'u implement edince geliyor ezberleme
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptorBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptorBaseAttribute>(true);

            classAttributes.AddRange(methodAttributes);
            var allAttributes = classAttributes; //kodun okunabilirliği açısından daha doğru olur. Çünkü class attribute'larını aldıktan sonra metodun üzerindekileri de ekledikten sonra o artık bir metodla ilgili tüm attribute'lar olur. Kodu okuyan bir kişinin anlaması daha kolay olacaktır. Yoksa bu yaptığıma pek de gerek yok.

            //allAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); //Bu kod her çalıştırılan metodun merkezi olarak loglanması nıdolayısıyla metodları kodlayacak olan yazılımcının metodun içine loglama kodlarını ekledi mi eklemedi mi derdiyle uğraşmamamızı sağlar.

            return allAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}