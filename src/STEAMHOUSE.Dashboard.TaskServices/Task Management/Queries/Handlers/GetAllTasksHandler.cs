using MediatR;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Models;
using STEAMHOUSE.Infrastruture.Repositories.Task_Management;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Queries.Handlers;

public class GetAllTasksHandler(ITaskRepository repository) 
    : IRequestHandler<GetAllTasks, IEnumerable<TaskListDto>>
{
    public async Task<IEnumerable<TaskListDto>> Handle(GetAllTasks request, CancellationToken cancellationToken)
    {

        var tasks = await repository.GetAllAsync();
        
        return tasks.Select(TaskListDto.Create);
    }
}