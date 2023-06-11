using Ayana.MailgunService;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;


public class MailgunServiceClass : IMailgunService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _domain;

    public MailgunServiceClass(string apiKey, string domain)
    {
        _apiKey = apiKey;
        _domain = domain;
        _httpClient = new HttpClient();
    }

    [Obsolete]
    public RestSharp.RestResponse SendEmail(string recipientEmail, string subject, string message)
    {
        RestClient client = new RestClient("https://api.mailgun.net/v3");

        RestSharp.RestRequest request = new RestSharp.RestRequest();
        request.AddParameter("domain", "sandbox88a6eff4d8924e7bb58ed3ab18073bf7.mailgun.org", RestSharp.ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "Excited User <mailgun@sandbox88a6eff4d8924e7bb58ed3ab18073bf7.mailgun.org>");
        request.AddParameter("to",recipientEmail);
        request.AddParameter("subject", subject);
        request.AddParameter("text", message);
        request.Method = RestSharp.Method.Post;

        string apiKey = "fff937c6161272edc197b20416ff89a3-6d1c649a-0f2959e2";
        request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("api:" + apiKey)));
        RestSharp.RestResponse response = client.Execute(request);

        return response;
    }

    
}