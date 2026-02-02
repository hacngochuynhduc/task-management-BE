using MediatR;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Commands;

public class DeleteTaskList : IRequest<bool>
{
    public Guid Id { get; set; }
}