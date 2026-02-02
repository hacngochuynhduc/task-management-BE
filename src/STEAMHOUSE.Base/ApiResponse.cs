namespace STEAMHOUSE.Base;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public int StatusCode { get; set; }

    public static ApiResponse<T> SuccessResponse(T data, string message = "Success") 
        => new ApiResponse<T> { Success = true, Data = data, Message = message, StatusCode = 200 };

    public static ApiResponse<T> FailResponse(string message, int statusCode = 400) 
        => new ApiResponse<T> { Success = false, Message = message, StatusCode = statusCode };
}