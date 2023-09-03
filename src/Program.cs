 
var builder = WebApplication.CreateBuilder(args);
{

}

builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie", o => {
        o.LoginPath = "/login";
        o.LogoutPath = "/logout";

    });

builder.Services.AddAuthorization();


var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.UseAuthorization();

}

app.MapGet("/login", Getlogin.Handler);
app.MapPost("/login", Login.Handler);
app.MapGet("/oauth/authorize", AuthorizationEndpoint.Handler).RequireAuthorization();
app.MapPost("/oauth/token", TokenEndpoint.Handler);


app.Run();