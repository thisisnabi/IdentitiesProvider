using Microsoft.AspNetCore.DataProtection;
using System.Text.Json;
using System.Web;

namespace Devblogs.IdentitiesProvider.Endpoints;

public static class OAuthEndpoints
{
    internal static IResult Handler(
   HttpRequest request,
   IDataProtectionProvider dataProtectionProvider

   )
    {

        request.Query.TryGetValue("response_type", out var responseType);
        request.Query.TryGetValue("client_id", out var clientId);
        request.Query.TryGetValue("code_challenge", out var codeChallenge);
        request.Query.TryGetValue("code_challenge_method", out var codeChallengeMethod);
        request.Query.TryGetValue("redirect_uri", out var redirectUri);
        request.Query.TryGetValue("scope", out var scope);
        request.Query.TryGetValue("state", out var state);

        var protector = dataProtectionProvider.CreateProtector("oauth");

        var code = new AuthCode
        {
            ClientId = clientId,
            CodeChallenge = codeChallenge,
            CodeChallengeMethod = codeChallengeMethod,
            RedirectUri = redirectUri,
            Expiry = DateTime.Now.AddMinutes(5)
        };


        var dataCode = protector.Protect(JsonSerializer.Serialize(code));


        return Results.Redirect($"{redirectUri}?code={dataCode}&" +
            $"state={state}&iss={HttpUtility.UrlEncode("https://localhost:7013")}");
    }

    internal static Task Handler(HttpContext context)
    {
        throw new NotImplementedException();
    }
}
