using System.Net;

namespace ProgramApp.Shared.Exceptions
{
    public class ProgramAppException : Exception
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode ErrorCode { get; set; }

        public ProgramAppException(string errorMessage, HttpStatusCode errorCode)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
    }
}
