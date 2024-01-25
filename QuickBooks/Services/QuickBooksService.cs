using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Newtonsoft.Json; // Make sure to have this package installed

public class QuickBooksService
{
    private readonly HttpClient _httpClient;
    private readonly string _clientId;
    private readonly string _clientSecret;
    private string _accessToken;
    private string _refreshToken;

    public QuickBooksService(HttpClient httpClient, string clientId, string clientSecret)
    {
        _httpClient = httpClient;
        _clientId = clientId;
        _clientSecret = clientSecret;
    }

    // Method to set initial tokens manually or retrieve them from secure storage
    public void SetTokens(string accessToken, string refreshToken)
    {
        _accessToken = accessToken;
        _refreshToken = refreshToken;
    }

    public async Task<string> RefreshAccessTokenAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://oauth.platform.intuit.com/oauth2/v1/tokens/bearer");
        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            {"grant_type", "refresh_token"},
            {"refresh_token", _refreshToken}
        });

        var basicAuthHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", basicAuthHeader);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var tokenData = JsonConvert.DeserializeObject<QuickBooksToken>(responseContent);

        _accessToken = tokenData.AccessToken;
        _refreshToken = tokenData.RefreshToken; // Update the refresh token as well

        // You should securely store the new access and refresh tokens

        return _accessToken;
    }

    // Method to create a bill in QuickBooks
    public async Task CreateBillAsync(BillData billData)
    {
        // Logic to create a bill in QuickBooks using _accessToken
        // Construct the request to QuickBooks API to create a bill
        // Handle the response
    }

    // Additional methods to interact with QuickBooks as needed
}
