using Newtonsoft.Json;
public class QuickBooksToken
{
    // Assuming the JSON keys in the response are "access_token", "refresh_token", etc.
    // Adjust these properties to match the exact JSON keys in the response.

    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    // Depending on the API, there might be additional fields like token type, scope, etc.
    // For example:
    // [JsonProperty("token_type")]
    // public string TokenType { get; set; }

    // [JsonProperty("scope")]
    // public string Scope { get; set; }
}
