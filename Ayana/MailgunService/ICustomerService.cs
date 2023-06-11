using Ayana.Data;
using System.Collections.Generic;

namespace Ayana.MailgunService
{
    public interface ICustomerService
    {
        List<ApplicationUser> GetInactiveCustomers();

    }
}
