namespace STEAMHOUSE.Base.Models;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public int StatusCode { get; set; }
    
    public static Result<T> Success(T data, string message = "Success", int statusCode = 200) 
        => new Result<T> { IsSuccess = true, Data = data, Message = message, StatusCode = statusCode };
    
    public static Result<T> Failure(string message, int statusCode = 400) 
        => new Result<T> { IsSuccess = false, Message = message, StatusCode = statusCode };
}