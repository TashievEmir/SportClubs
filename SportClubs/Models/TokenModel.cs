using SportClubs.Helpers;

namespace SportClubs.Models
{
    public class TokenModel
    {
        public string AccessToken { get; set; }
        public string User { get; set; }
        public string Role { get; set; }
    }
}
