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
        request.AddParameter("domain", "sandbox1219ccda395b4a0bb2410b5b7376da7a.mailgun.org", RestSharp.ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "Excited User <mailgun@sandbox1219ccda395b4a0bb2410b5b7376da7a.mailgun.org>");
        request.AddParameter("to",recipientEmail);
        request.AddParameter("subject", subject);
        request.AddParameter("text", message);
        request.Method = RestSharp.Method.Post;

        string apiKey = "87a566fbabc4f7046dc86478f9cfb8d8-6d1c649a-79b20914";
        request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("api:" + apiKey)));
        RestSharp.RestResponse response = client.Execute(request);

        return response;
    }

    
}