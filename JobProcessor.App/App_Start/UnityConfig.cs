using JobProcessor.App.Services;
using JobProcessor.DataAccess.ContextConfig;
using JobProcessor.DataAccess.JobsRepository;
using JobProcessor.Domain.Services;
using System;
using Unity;
using Unity.Injection;

namespace JobProcessor.App.App_Start
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container =
        new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterServices(container);
            return container;
        });

        public static IUnityContainer Container => container.Value;

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IDbContext, JobProcessorContext>();
            container.RegisterType<IJobsRepository, JobsRepository>();
            container.RegisterType<IIntermediaryMappingService, IntermediaryMapper>();
            container.RegisterType<IJobService, JobService>(); 
            container.RegisterType<IInfoMessagingService, InfoMessagingService>(new InjectionConstructor("defaultTitle", 
                "defaultMessage", "defaultCssClass" ));

        }
    }
}