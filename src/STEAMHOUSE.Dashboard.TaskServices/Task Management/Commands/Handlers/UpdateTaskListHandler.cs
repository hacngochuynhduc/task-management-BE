using MediatR;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Models;
using STEAMHOUSE.Infrastruture.Manager;
using STEAMHOUSE.Infrastruture.Repositories.Task_Management;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Commands.Handlers;

public class UpdateTaskListHandler(
    ITaskRepository repository, 
    IUnitOfWork unitOfWork) 
    : IRequestHandler<UpdateTaskList, TaskListDto>
{
    public async Task<TaskListDto> Handle(UpdateTaskList request, CancellationToken cancellationToken)
    {
        var task = await repository.GetByIdAsync(request.Id);
        if (task == null) throw new Exception("Không tìm thấy task để cập nhật");
        
        task.Title = request.Title;
        task.Description = request.Description;
        task.Status = request.Status;

        task.UpdatedDate = DateTime.UtcNow;
        
        await repository.UpdateAsync(task);
        await unitOfWork.SaveChangesAsync();

        return TaskListDto.Create(task);
    }
}