namespace MySecrets.Domain.Entities.Users
{
    public class User : EntityBase
    {
        public virtual string? Login { get; set; }
        public virtual string? Email { get; set; }
        public virtual string? Password { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual IList<FriendRelationship>? Friends { get; set; }
        

    }
}
