using MediatR;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Models;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Commands;

public class UpdateTaskStatus : IRequest<TaskListDto>
{
    public Guid Id { get; set; }
    public int Status { get; set; }
}