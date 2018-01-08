using RestSharp.Deserializers;

namespace Client.Models
{
    public class TokenResponse
    {
        [DeserializeAs(Name = "access_token")]
        public string AuthToken { get; set; }
    }
}