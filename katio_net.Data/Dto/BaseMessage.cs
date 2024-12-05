using System.Net;

namespace katio.Data.Dto;

public class BaseMessage<T>
where T: class
{
    public string Message {get; set;}
    
    public HttpStatusCode statusCode {get; set;}

    public int TotalElements {get; set;}

    public List<T> ResponseElements {get; set;}
}

public static class BaseMessageStatus
{
    public const string OK_200 = "200 Ok";
    public const string BAD_REQUEST_400 = "400 Bad Request";
    public const string INTERNAL_SERVER_500 = "500 Internal server error";
    public const string  NOT_FOUND_404 = "404 Not found";
    public const string  BOOK_NOT_FOUND = "404 Book not found";
}