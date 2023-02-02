
public class BaseViewModel<T> where T : new()
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public long TimerProcessing { get; set; } = 0;
    public T Data { get; set; } = new T();

    public void GenerateError(T item, string message)
    {
        Message = message;
        Success = false;
    }
}