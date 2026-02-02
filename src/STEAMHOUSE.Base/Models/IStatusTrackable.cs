namespace STEAMHOUSE.Base.Models;

public interface IStatusTrackable<T>
{
    T Id { get; set; }
    bool IsActive  { get; set; }
}