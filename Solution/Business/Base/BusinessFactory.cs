using System;
using System.Reflection;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Text;
using System.IO;


namespace Business.Base
{
    public class BusinessFactory
    {
        private static BusinessFactory instance;

        public static BusinessFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new BusinessFactory();
            }

            return instance;
        }

        private BusinessFactory()
        {
            try
            {
                Assembly asm = Assembly.GetAssembly(this.GetType());

                foreach (Type type in asm.GetTypes())
                {
                    var tipoBase = type.BaseType;
                    if (type != null && tipoBase != null)
                    {
                        if (type.BaseType.Name.Equals(typeof(BaseConnectedBusinessFacade<>).Name)
                            //|| type.BaseType.Name.Equals(typeof(BaseConnectedBusinessFacade<>).Name)
                            && !type.IsAbstract)
                        {
                            if (!ContainerManager.Instance.IsRegistered(type))
                            {
                                ContainerManager.Instance.RegisterType(type,
                                    new TransientLifetimeManager(),
                                    new Interceptor<VirtualMethodInterceptor>(),
                                    new InterceptionBehavior<BusinessMethodManagementBehavior>());
                            }
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Exception exSub in ex.LoaderExceptions)
                {
                    sb.AppendLine(exSub.Message);
                    FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                    if (exFileNotFound != null)
                    {
                        if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                        {
                            sb.AppendLine("Fusion Log:");
                            sb.AppendLine(exFileNotFound.FusionLog);
                        }
                    }
                    sb.AppendLine();
                }
                string errorMessage = sb.ToString();                
            }
        }

        public T Get<T>()
        {
            return ContainerManager.Instance.Get<T>();
        }
    }
}
