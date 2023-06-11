using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Ayana.MailgunService
{
    public class EmailService : IEmailService
    {
        private readonly IMailgunService _mailgunService;

        public EmailService(IMailgunService mailgunService)
        {
            _mailgunService = mailgunService;
        }


        public void SendVerificationCode(string email)
        {
            string code = GenerateCode();
            string subject = "Registration Verification";
            string body = $"Your verification code is: {code}";

            // Save the verification code in your data store or cache
            SaveVerificationCode(code, TimeSpan.FromMinutes(10));

            SendEmailToCustomer(email, subject, body);
        }
        public  string GetVerificationCode()
        {
            return Cache.Get(CacheKey) as string;
        }
        public bool VerifyCode(string email, string code)
       {
             //Retrieve the saved verification code from your data store or cache
            string savedCode = GetVerificationCode();

            // Compare the provided code with the saved code
            return code == savedCode;
        }

        public string GenerateCode()
        {
            // Generate a random 4-digit verification code
            Random random = new Random();
            int code = random.Next(1000, 9999);
            return code.ToString();
        }

        private static readonly IMemoryCache Cache = new MemoryCache(new MemoryCacheOptions());
        private const string CacheKey = "VerificationCode";

        public  void SaveVerificationCode(string code, TimeSpan expirationTime)
        {
            Cache.Set(CacheKey, code, DateTimeOffset.Now.Add(expirationTime));
        }

        public void SaveCodeToCache(string email, string code)
        {
            // Cache the verification code for the specified email address
            Cache.Set(email, code, TimeSpan.FromMinutes(10));
        }

        public void SendEmailToCustomer(string email, string subject, string body)
        {
            // Code to send email using Mailgun service
            _mailgunService.SendEmail(email, subject, body);
        }
    }
}
