namespace dimitricarter_blog.Controllers
{
    internal class MailMessenger
    {
        private string from;
        private object p;

        public MailMessenger(string from, object p)
        {
            this.from = from;
            this.p = p;
        }

        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}