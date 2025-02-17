namespace BookStore.Common.Response
{
    public class ServiceResponse<T>
    {
        public string Message { get; set; } = "";
        public bool Succeeded { get; set; } = true;
        public T? Data { get; set; }
    }
}
