

using MediatR;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Models;
using STEAMHOUSE.Infrastruture.Manager;
using STEAMHOUSE.Infrastruture.Repositories.Task_Management;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Commands.Handlers;

public class CreateTaskListHandler(
    ITaskRepository repository,
    IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateTaskList, TaskListDto>
{
    public async Task<TaskListDto> Handle(CreateTaskList request, CancellationToken cancellationToken)
    {
        var table = CreateTaskList.Create(request);
        
        await repository.AddAsync(table);
        
        await unitOfWork.SaveChangesAsync();

        return TaskListDto.Create(table);
    }
}