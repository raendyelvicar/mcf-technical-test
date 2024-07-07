namespace BPKBManagementAPI.Data
{
    public class BaseResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
    }
}
