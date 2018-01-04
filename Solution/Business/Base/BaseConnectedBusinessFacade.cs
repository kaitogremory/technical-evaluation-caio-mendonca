namespace Business.Base
{
    public abstract class BaseConnectedBusinessFacade<T> : BaseBusinessFacade where T : class
    {
        protected T dataAccess;

        protected BaseConnectedBusinessFacade()
        {
            dataAccess = ContainerManager.Instance.Get<T>();
        }
    }
}
