using MySecrets.CrossCutting.Emails;
using MySecrets.Domain.Entities.Users;

namespace MySecrets.Domain.Exceptions.Users
{
    public class RegisterUserMessage : IEmailMessage
    {
        public RegisterUserMessage(User user, string from)
        {
            this.User = user;
            this.From = from;
        }
        public User User { get; set; }
        public IList<string>? To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
