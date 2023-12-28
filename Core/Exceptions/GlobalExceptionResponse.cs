namespace Core.Exceptions;

public class GlobalExceptionResponse(
    int statusCode, 
    string exceptionMessage, 
    string? details = null)
{
    public int StatusCode { get; set; } = statusCode;
    public string ExceptionMessage { get; set; } = exceptionMessage;
    public string? Details { get; set; } = details;
}
