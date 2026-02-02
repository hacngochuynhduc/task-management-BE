using STEAMHOUSE.Base.Entities;
using STEAMHOUSE.Base.Enum;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Models;

public class TaskListDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public WorkStatus Status { get; set; }
    public DateTime? CreatedDate { get; set; }

    public static TaskListDto Create(TaskList entity)
    {
        return new TaskListDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Status = entity.Status,
            CreatedDate = entity.CreatedDate
        };
    }
}