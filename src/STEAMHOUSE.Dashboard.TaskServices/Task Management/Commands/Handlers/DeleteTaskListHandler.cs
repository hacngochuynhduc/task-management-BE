using MediatR;
using STEAMHOUSE.Infrastruture.Manager;
using STEAMHOUSE.Infrastruture.Repositories.Task_Management;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Commands.Handlers;

public class DeleteTaskListHandler(
    ITaskRepository repository, 
    IUnitOfWork unitOfWork) 
    : IRequestHandler<DeleteTaskList, bool>
{
    public async Task<bool> Handle(DeleteTaskList request, CancellationToken cancellationToken)
    {
        var task = await repository.GetByIdAsync(request.Id);
        
        if (task == null) return false;
        
        await repository.Delete(task);

        await unitOfWork.SaveChangesAsync();

        return true;
    }
}