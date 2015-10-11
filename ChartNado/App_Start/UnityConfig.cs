namespace ChartNado
{
    using System.Web.Mvc;
    using Microsoft.Practices.Unity;
    using Models.Dev.Repos;
    using Models.Dev.Services;
    using Unity.Mvc5;
    using Utils;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            if (ApplicationConfiguration.ApplicationMode == ApplicationDevModeEnum.Dev)
            {
                RegisterDevDependencies(container);
            }

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void RegisterDevDependencies(UnityContainer container)
        {
            container.RegisterType<IDevEmployeeRepo, DevEmployeeRepo>();
            container.RegisterType<IDevEmployeeService, DevEmployeeService>();
        }
    }
}