using MailKit.Net.Smtp;
using MimeKit;

namespace GammingCenter.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(
            string toEmail,
            string subject,
            string body)
        {
            // Create a new email message
            var email = new MimeMessage();

            // Set the sender email
            email.From.Add(
                new MailboxAddress(
                    "Gaming Center",
                    "your-email@gmail.com"));

            // Set the receiver email
            email.To.Add(
                MailboxAddress.Parse(toEmail));

            // Set the email subject
            email.Subject = subject;

            // Set the email body
            email.Body = new TextPart("plain")
            {
                Text = body
            };

            // Create SMTP client
            using var smtp = new SmtpClient();

            // Connect to Gmail SMTP server
            await smtp.ConnectAsync(
                "smtp.gmail.com",
                587,
                MailKit.Security.SecureSocketOptions.StartTls);

            // Authenticate using Gmail App Password
            await smtp.AuthenticateAsync(
                "your-email@gmail.com",
                "your-app-password");

            // Send the email
            await smtp.SendAsync(email);

            // Disconnect from SMTP server
            await smtp.DisconnectAsync(true);
        }
    }
}