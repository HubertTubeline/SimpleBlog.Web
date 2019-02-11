namespace SimpleBlog.DAL.Utils
{
    public class OperationDetails
    {
        public OperationDetails(bool isSuccess, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public bool IsSuccess { get; }
        public string Message { get; }
    }
}
