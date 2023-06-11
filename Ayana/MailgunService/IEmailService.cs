using System;

namespace Ayana.MailgunService
{
    public interface IEmailService
    {
        void SendEmailToCustomer(string email, string subject, string body);
        void SendVerificationCode(string email);
         string GetVerificationCode();
        bool VerifyCode(string email, string code);
        string GenerateCode();
        void SaveVerificationCode(string code, TimeSpan expirationTime);
        void SaveCodeToCache(string email, string code);
    }
}
