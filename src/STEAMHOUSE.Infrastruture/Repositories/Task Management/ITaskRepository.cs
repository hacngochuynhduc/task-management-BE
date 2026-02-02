using STEAMHOUSE.Base.Entities;
using STEAMHOUSE.Infrastruture.Manager;

namespace STEAMHOUSE.Infrastruture.Repositories.Task_Management;

public interface ITaskRepository : IRepository<TaskList, Guid>
{
}