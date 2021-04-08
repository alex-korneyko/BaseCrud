namespace BaseCrud.Domain
{
    public interface IHasOwner
    {
        // public long UserId { get; set; }
        public AppUser Owner { get; set; }
    }
}