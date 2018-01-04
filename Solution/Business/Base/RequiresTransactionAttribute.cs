using System;

namespace Business.Base
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RequiresTransactionAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionSupressAttribute : Attribute
    {
    }
}
