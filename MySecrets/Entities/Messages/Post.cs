namespace MySecrets.Domain.Entities.Messages
{
    public class Post : EntityBase
    {
        public virtual DateTime? CreatedAt { get; set; }
        public virtual string Title { get; set; } = string.Empty;
        public virtual IList<Message>? ChildMessages { get; set; }

    }
}
