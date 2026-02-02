using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using STEAMHOUSE.Base.Models;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Commands;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Models;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Queries;

namespace STEAMHOUSE.Dashboard.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[EnableCors("AllowSpecificOrigins")]
public class TasksController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<Result<TaskListDto>> CreateAsync([FromBody] CreateTaskList command)
    {
        var data = await mediator.Send(command);
        return Result<TaskListDto>.Success(data, "Tạo mới Task thành công");
    }

    [HttpPut("{id:guid}")]
    public async Task<Result<TaskListDto>> UpdateAsync(Guid id, [FromBody] UpdateTaskList command)
    {
        command.Id = id;
        var data = await mediator.Send(command);
        return Result<TaskListDto>.Success(data, "Cập nhật Task thành công");
    }

    [HttpGet]
    public async Task<Result<IEnumerable<TaskListDto>>> GetAllAsync([FromQuery] GetAllTasks query)
    {
        var data = await mediator.Send(query ?? new GetAllTasks());
        return Result<IEnumerable<TaskListDto>>.Success(data);
    }

    [HttpGet("{id:guid}")]
    public async Task<Result<TaskListDto>> GetByIdAsync(Guid id)
    {
        var data = await mediator.Send(new GetTaskListById(id));
        return data != null 
            ? Result<TaskListDto>.Success(data) 
            : Result<TaskListDto>.Failure("Không tìm thấy Task yêu cầu");
    }

    [HttpDelete("{id:guid}")]
    public async Task<Result<bool>> DeleteAsync(Guid id)
    {
        var isDeleted = await mediator.Send(new DeleteTaskList { Id = id });
        return isDeleted 
            ? Result<bool>.Success(true, "Xóa Task thành công") 
            : Result<bool>.Failure("Xóa Task thất bại hoặc không tồn tại Task");
    }
    
    [HttpPatch("{id:guid}/status")]
    public async Task<Result<TaskListDto>> UpdateStatusAsync(Guid id, [FromBody] int newStatus)
    {
        // Chúng ta bọc id và status vào command để gửi qua Mediator
        var command = new UpdateTaskStatus { Id = id, Status = newStatus };
        var data = await mediator.Send(command);
    
        return data != null 
            ? Result<TaskListDto>.Success(data, "Cập nhật trạng thái thành công") 
            : Result<TaskListDto>.Failure("Không tìm thấy Task để cập nhật");
    }
}