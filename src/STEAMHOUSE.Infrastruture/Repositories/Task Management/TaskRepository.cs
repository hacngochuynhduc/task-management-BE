using STEAMHOUSE.Base.Entities;
using STEAMHOUSE.Infrastruture.Data;
using STEAMHOUSE.Infrastruture.Manager;

namespace STEAMHOUSE.Infrastruture.Repositories.Task_Management;

public class TaskRepository(ApplicationDbContext dbContext)
    : Repository<TaskList, Guid>(dbContext), ITaskRepository
{

}