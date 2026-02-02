using MediatR;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Commands;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Models;
using STEAMHOUSE.Infrastruture.Repositories.Task_Management;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Commands.Handlers;

public class UpdateTaskStatusHandler(ITaskRepository taskRepository) 
    : IRequestHandler<UpdateTaskStatus, TaskListDto>
{
    public async Task<TaskListDto> Handle(UpdateTaskStatus request, CancellationToken cancellationToken)
    {
        var task = await taskRepository.GetByIdAsync(request.Id);
        
        if (task == null)
        {
            return null!;
        }
        
        task.Status = (STEAMHOUSE.Base.Enum.WorkStatus)request.Status;
        await taskRepository.UpdateAsync(task);


        return new TaskListDto
        {
            Id = task.Id,
            Title = task.Title,
            Status = task.Status
        };
    }
}