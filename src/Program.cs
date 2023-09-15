
using Microsoft.AspNetCore.Identity;
using System;

var builder = WebApplication.CreateBuilder(args);
{
    //
    builder.Services.AddAuthorization();

    // Add EF Core
    builder.Services.AddDbContext<IdentitiesDbContext>(options =>
        options.UseInMemoryDatabase("devblogs_inmemory_db"));

    builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                        .AddEntityFrameworkStores<IdentitiesDbContext>();
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
 
var app = builder.Build();
{
    app.MapGroup("/Identity")
            .MapIdentityApi<IdentityUser>();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();