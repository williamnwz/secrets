using System.Text.RegularExpressions;

namespace MySecrets.Domain.Entities.ValueObjects
{
    public class Email : ValueObject<string>
    {
        public Email(string email) : base(email) { }
        public override bool IsValid()
        {
            var emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            return emailRegex.IsMatch(this.Value);
        }
    }
}
