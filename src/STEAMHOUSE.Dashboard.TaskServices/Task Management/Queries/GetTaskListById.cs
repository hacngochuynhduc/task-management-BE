using MediatR;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Models;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Queries;

public class GetTaskListById : IRequest<TaskListDto>
{
    public Guid Id { get; set; }

    public GetTaskListById(Guid id)
    {
        Id = id;
    }
}