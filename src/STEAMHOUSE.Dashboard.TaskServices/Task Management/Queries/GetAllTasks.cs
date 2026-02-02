using MediatR;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Models;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Queries;

public class GetAllTasks : IRequest<IEnumerable<TaskListDto>>
{

}