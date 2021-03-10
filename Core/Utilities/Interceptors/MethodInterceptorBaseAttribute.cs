using System;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    //AllowMultiple=true olmasını sebebi örneğin loglama işlemi yapacağız ve veritabanı,dosya,sms gibi birden fazla kaynak ile loglama yapabiliriz ondan dolayı.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptorBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //Hangi attribute'un önce çalışacağını belirlemek için

        /// <summary>
        /// Implementation of IInterceptor
        /// </summary>
        /// <param name="invocation"></param>
        public abstract void Intercept(IInvocation invocation);
    }
}
