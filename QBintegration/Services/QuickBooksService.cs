using QuickBooks.Models; // Check the correct namespace
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Newtonsoft.Json; // Make sure to have this package installed

namespace QuickBooks.Services
{
    public class QuickBooksService : IQuickBooksService
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _redirectUri;

        public QuickBooksService(HttpClient httpClient, string clientId, string clientSecret, string redirectUri)
        {
            _httpClient = httpClient;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _redirectUri = redirectUri;
        }

        public async Task<QuickBooksToken> GetAccessTokenAsync(string code)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://oauth.platform.intuit.com/oauth2/v1/tokens/bearer");
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"grant_type", "authorization_code"},
                {"code", code},
                {"redirect_uri", _redirectUri}
            });

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}")));

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<QuickBooksToken>(responseContent);
        }

        public string GetAuthorizationUrl()
        {
            // Assuming "scope" and "state" are defined or configurable
            return $"https://appcenter.intuit.com/connect/oauth2?client_id={_clientId}&redirect_uri={_redirectUri}&scope=YOUR_SCOPE&response_type=code&state=YOUR_STATE";
        }
    }
}
