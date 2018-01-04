using Business.Base;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace Business.Base
{
    public class BusinessMethodManagementBehavior : IInterceptionBehavior
    {
        private const string GENERAL_CATEGORY = "General";


        public BusinessMethodManagementBehavior()
        {
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn result = null;

            try
            {
                if (input.MethodBase.IsDefined(typeof(TransactionSupressAttribute), true))
                {
                    using (var scope = new TransactionScope(TransactionScopeOption.Suppress,
                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                    {
                        result = getNext().Invoke(input, getNext);

                        if (result.Exception != null)
                        {
                            throw result.Exception;
                        }

                        scope.Complete();
                    }
                }
                else if (input.MethodBase.IsDefined(typeof(RequiresTransactionAttribute), true))
                {
                    using (var scope = new TransactionScope(TransactionScopeOption.Required,
                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                    {
                        result = getNext().Invoke(input, getNext);

                        if (result.Exception != null)
                        {
                            throw result.Exception;
                        }

                        scope.Complete();
                    }
                }
                else
                {
                    result = getNext().Invoke(input, getNext);
                    if (result.Exception != null)
                    {
                        throw result.Exception;
                    }
                }
            }            
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
