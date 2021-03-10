using System;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterceptor : MethodInterceptorBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception exception) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            bool success = true;

            OnBefore(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                success = false;
                OnException(invocation, exception);
                throw;
            }
            finally
            {
                if (success)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
