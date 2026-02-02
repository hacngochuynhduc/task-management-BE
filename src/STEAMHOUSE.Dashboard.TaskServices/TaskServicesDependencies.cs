using Microsoft.Extensions.DependencyInjection;
using MediatR;
using STEAMHOUSE.Infrastruture.Repositories.Task_Management;

namespace STEAMHOUSE.Dashboard.TaskServices;

public static class TaskServicesDependencies
{
    public static IServiceCollection AddTaskServices(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        // 1. Đăng ký Repository đặc thù cho Task
        services.AddScoped<ITaskRepository, TaskRepository>();
        
        return services;
    }
}