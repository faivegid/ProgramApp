namespace ProgramApp.Shared.Responses
{
    public class ErrorObject
    {
        public string ErrorMessage { get; set; }
        public object ErrorData { get; set; }

        public ErrorObject()
        {
        }

        public ErrorObject(string message, object errorObject)
        {
            ErrorMessage = message;
            ErrorData = errorObject;
        }
    }
}
