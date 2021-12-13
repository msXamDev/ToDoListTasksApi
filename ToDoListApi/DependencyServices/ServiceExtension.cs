using ToDoListApi.Services;

namespace ToDoListApi.DependencyServices
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterServices(
               this IServiceCollection services)
        {
            services.AddTransient<IToDoListRepository, ToDoListRepository>();
            return services;
        }
    }
}
