using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class MailData
    {
        // Receiver
        [EmailAddress]
        public string? To { get; }

        // Sender
        public string? From { get; }

        public string? DisplayName { get; }

        public string? ReplyTo { get; }

        public string? ReplyToName { get; }

        // Content
        public string Subject { get; }

        public string? Body { get; }
        
        //Token
        public string? Token { get; set; }

        public MailData(string? to = null, string? from = null, string? Token = null)
        {
            // Receiver
            To = to;
            // Sender
            From = from;
            ReplyTo = "bitran202@gmail.com";
            ReplyToName = "System Administrator";
            
            // Content
            Subject = "Reset password";
            Body = "Hello, To reset the password for your account, please click on the following link: "+Token+"";
        }
    }
}