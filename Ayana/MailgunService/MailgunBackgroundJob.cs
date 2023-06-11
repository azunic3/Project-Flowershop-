using Ayana.MailgunService;
using System;
using System.Threading;

namespace Ayana.MailgunService
{
    public class MailgunBackgroundJob
    {
        private readonly IEmailService _emailService;
        private readonly ICustomerService _customerService;
        private Timer _timer;

        public MailgunBackgroundJob(IEmailService emailService, ICustomerService customerService)
        {
            _emailService = emailService;
            _customerService = customerService;
        }

        public void Start()
        {
            // Set up a timer to execute the CheckAndSendEmail method every 24 hours
            _timer = new Timer(CheckAndSendEmail, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
        }

        public void Stop()
        {
            // Stop the timer
            _timer?.Change(Timeout.Infinite, 0);
        }

        public void CheckAndSendEmail(object state)
        {
            // Get customers who haven't made a purchase in the last 30 days
            var inactiveCustomers = _customerService.GetInactiveCustomers();

            foreach (var customer in inactiveCustomers)
            {
                // Send email to the customer
                _emailService.SendEmailToCustomer(customer.Email, "Reminder: Make a purchase!", "You haven't made a purchase in 30 days. Take advantage of our latest offers and shop now!");
            }
        }
    }
}
