namespace MovieRating.Features
{
    public class Response<T> where T : class
    {
        public bool Status { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public Response(T Data,string Message)
        {
            this.Status = true;
            this.Data = Data;
            this.Message = Message;
        }
    }
}
