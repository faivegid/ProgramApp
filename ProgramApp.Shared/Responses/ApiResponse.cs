using System.Net;

namespace ProgramApp.Shared.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public ErrorObject Error { get; set; }
        public int StatusCode { get; set; }

        public ApiResponse() { }

        public ApiResponse(T data, HttpStatusCode statusCode)
        {
            Data = data;
            Message = statusCode.ToString();
            StatusCode = (int)statusCode;
        }
    }

    public static class ApiResponse
    {
        public static ApiResponse<T> Success<T>(T Data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ApiResponse<T>(Data, statusCode);
        }

        public static ApiResponse<object> Error(string errorMsg, HttpStatusCode statusCode = HttpStatusCode.BadRequest, object errorObject = null)
        {
            return new ApiResponse<object>
            {
                Message = statusCode.ToString(),
                StatusCode = (int)statusCode,
                Error = new ErrorObject(errorMsg, errorObject)
            };
        }
    }
}
