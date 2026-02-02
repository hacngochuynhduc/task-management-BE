namespace STEAMHOUSE.Base.Models;

public abstract class BaseEntity<T> : IEntity<T>, IStatusTrackable<T>
{
    public Guid? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; } = false;

    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    
    public T Id { get; set; }
    public bool IsActive { get; set; } = true;
}