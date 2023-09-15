using Microsoft.Extensions.Primitives;

namespace Devblogs.IdentitiesProvider.Endpoints
{
    internal class AuthCode
    {
        public StringValues ClientId { get; set; }
        public StringValues CodeChallenge { get; set; }
        public StringValues CodeChallengeMethod { get; set; }
        public StringValues RedirectUri { get; set; }
        public DateTime Expiry { get; set; }
    }
}