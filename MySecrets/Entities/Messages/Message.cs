namespace MySecrets.Domain.Entities.Messages
{
    public class Message : EntityBase
    {
        public virtual DateTime? CreatedAt { get; set; }
        public virtual string? Description { get; set; }
        public virtual IList<Message>? Messages { get; set; }
    }
}
