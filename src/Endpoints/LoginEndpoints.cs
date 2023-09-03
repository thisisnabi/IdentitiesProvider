using System.Web;

namespace Devblogs.IdentitiesProvider.Endpoints;

public static class LoginEndpoints
{
    internal static async Task<IResult> Handler(
           HttpContext httpContext,
           string returnUrl)
    {
        await httpContext.SignInAsync("cookie",
            new ClaimsPrincipal(
                    new ClaimsIdentity(
                            new Claim[]
                            {
                                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString())
                            },
                            "cookie"
                        )
                ));

        return Results.Redirect(returnUrl);
    }

    internal static async Task Handler(string returnUrl, HttpResponse response)
    {
        response.Headers.ContentType = "text/html";

        await response.WriteAsync(
        $"""
                <html>
                    <head><title>Login</title></head>
                    <body>
                        <form action="/login?returnUrl={HttpUtility.UrlEncode(returnUrl)}" method="post">
                            <input value="submit" type="submit"/>
                        </form>
                    </body>
                </html>
            """);
    }
}
