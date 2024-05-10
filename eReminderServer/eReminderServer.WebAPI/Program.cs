using Azure.Identity;
using DefaultCorsPolicyNugetPackage;
using eReminderServer.Application;
using eReminderServer.Domain.Entities;
using eReminderServer.Infrastructure;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultCors();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors();


app.UseAuthorization();

app.MapControllers();

using (var scoped =app.Services.CreateScope())
{
    var userMenager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    if (!userMenager.Users.Any())
    {
        userMenager.CreateAsync(new()
        {
            FirstName="Mustafa",
            LastName="Kösem",
            Email="admin@admin.com",
            UserName="admin",
        },"1").Wait();
    }
}

app.Run();
