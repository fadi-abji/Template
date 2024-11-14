namespace BlazorWebAppWithIdentity.Criterias
{
    public interface IObject
    {
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ChangedAt { get; set; }
        public int ChangedBy { get; set; }
    }
}
