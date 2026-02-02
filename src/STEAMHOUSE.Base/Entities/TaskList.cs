using STEAMHOUSE.Base.Enum;
using STEAMHOUSE.Base.Models;

namespace STEAMHOUSE.Base.Entities;

public class TaskList : BaseEntity<Guid>
{
 
    public string Title { get; set; }
    public string Description { get; set; }
    public WorkStatus Status { get; set; }
    
}