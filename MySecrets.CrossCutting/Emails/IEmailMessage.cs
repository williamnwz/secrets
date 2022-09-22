namespace MySecrets.CrossCutting.Emails
{
    public interface IEmailMessage
    {
        public IList<string> To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
