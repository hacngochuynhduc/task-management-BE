using MediatR;
using STEAMHOUSE.Base.Entities;
using STEAMHOUSE.Base.Enum;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Models;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Commands;

public class CreateTaskList : IRequest<TaskListDto>
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public WorkStatus Status { get; set; } = WorkStatus.Todo; // Dùng WorkStatus

    public static TaskList Create(CreateTaskList request)
    {
        return new TaskList
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Status = request.Status,
            CreatedDate = DateTime.UtcNow
        };
    }
}