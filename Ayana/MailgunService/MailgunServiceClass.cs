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
        request.AddParameter("domain", "sandbox9868192fc16447739de7f5cf57633817.mailgun.org", RestSharp.ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "Excited User <mailgun@sandbox9868192fc16447739de7f5cf57633817.mailgun.org>");
        request.AddParameter("to",recipientEmail);
        request.AddParameter("subject", subject);
        request.AddParameter("text", message);
        request.Method = RestSharp.Method.Post;

        string apiKey = "d3cd6e4960a1029b0f385383d6c74467-af778b4b-0d8be1d3";
        request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("api:" + apiKey)));
        RestSharp.RestResponse response = client.Execute(request);

        return response;
    }

    
}