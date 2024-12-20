﻿namespace Business.Models
{
    public class UploadResultEventArgs : EventArgs
    {
        public bool Uploaded { get; set; }
        public string? FileName { get; set; }
        public string? StoredFileName { get; set; }
        public int ErrorCode { get; set; }
        public UploadHttpRequest Request { get; set; } = new UploadHttpRequest();

    }
}
