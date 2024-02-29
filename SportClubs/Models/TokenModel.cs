using SportClubs.Helpers;

namespace SportClubs.Models
{
    public class TokenModel
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string User { get; set; }
        public string Role { get; set; }
    }
}
