namespace Ayana.MailgunService
{
    public class MailgunBackgroundJob
    {
        private readonly IEmailService _emailService;
        private readonly ICustomerService _customerService;

        public MailgunBackgroundJob(IEmailService emailService, ICustomerService customerService)
        {
            _emailService = emailService;
            _customerService = customerService;
        }
        public void CheckAndSendEmail()
        {
            // Get customers who haven't made a purchase in the last 30 days
            var inactiveCustomers = _customerService.GetInactiveCustomers();

            foreach (var customer in inactiveCustomers)
            {
                 //Send email to the customer
                _emailService.SendEmailToCustomer(customer.Email, "You do not need a special occasion to suprise the one you love","There is no need to wait for something special to suprise the ones you love. They are the ones making the moment special, show them your love with our");
            }
        }
    }
}
