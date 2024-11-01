namespace School.BLL
{
    public class OperationResult
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
    }
    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }
    }
}
