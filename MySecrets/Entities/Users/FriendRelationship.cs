namespace MySecrets.Domain.Entities.Users
{
    public class FriendRelationship : EntityBase
    {
        public virtual User? Me { get; set; }
        public virtual User? Friend { get; set; }
        public virtual bool IsChecked { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
    }
}


