using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Business.Base
{
    public class ContainerManager
    {
        private static ContainerManager instance;

        private IUnityContainer container;

        public static ContainerManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContainerManager();
                }

                return instance;
            }
        }

        private ContainerManager()
        {
            container = new UnityContainer().LoadConfiguration();
            container.AddNewExtension<Interception>();
        }

        public void RegisterMapper<TInterface, TDataAccess>()
        {
            container.RegisterType(typeof(TInterface), typeof(TDataAccess));
        }

        public T Get<T>()
        {
            if (!container.IsRegistered<T>())
            {
                container.RegisterType<T>(
                new TransientLifetimeManager(),
                new Interceptor<VirtualMethodInterceptor>(),
                new InterceptionBehavior<BusinessMethodManagementBehavior>());
            }
            return container.Resolve<T>();
        }

        public bool IsRegistered(Type type)
        {
            return this.container.IsRegistered(type);
        }

        public void RegisterType(Type typeInterface, Type typeDataAccess)
        {
            this.container.RegisterType(typeInterface);
            this.container.RegisterType(typeDataAccess);
        }

        public void RegisterType(Type type, LifetimeManager transientLifetimeManager, params InjectionMember[] injectionMembers)
        {
            this.container.RegisterType(type, transientLifetimeManager, injectionMembers);
        }
    }
}
