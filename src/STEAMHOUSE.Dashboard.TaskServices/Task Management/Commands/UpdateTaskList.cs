using MediatR;
using STEAMHOUSE.Base.Enum;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Models;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Commands;

public class UpdateTaskList : IRequest<TaskListDto>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public WorkStatus Status { get; set; }
}