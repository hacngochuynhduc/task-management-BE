using MediatR;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Models;
using STEAMHOUSE.Infrastruture.Repositories.Task_Management;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Queries.Handlers;

public class GetTaskListByIdHandler(ITaskRepository repository) 
    : IRequestHandler<GetTaskListById, TaskListDto>
{
    public async Task<TaskListDto> Handle(GetTaskListById request, CancellationToken cancellationToken)
    {
        var task = await repository.GetByIdAsync(request.Id);
        
        if (task == null)
        {
            throw new Exception("Task not found");
        }

        // 3. Map từ Entity sang DTO và trả về
        return TaskListDto.Create(task);
    }
}