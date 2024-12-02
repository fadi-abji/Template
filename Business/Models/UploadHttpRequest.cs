namespace Business.Models
{
    [HideFromApiRef]
    public class UploadHttpRequest
    {
        public int Status { get; set; }

        public string StatusText { get; set; }

        public string ResponseType { get; set; }

        public string ResponseText { get; set; }
    }
}
