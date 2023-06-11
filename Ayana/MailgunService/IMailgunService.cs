using RestSharp;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace Ayana.MailgunService
{
    public interface IMailgunService
    {
        RestSharp.RestResponse SendEmail(string email, string subject, string body);

    }
}
