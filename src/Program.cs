using AllisonOwenWedding.DataAccess;
using AllisonOwenWedding.Models;
using AllisonOwenWedding.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton(new EmailVariables()
{
    EmailUsername = builder.Configuration["EmailUsername"],
    EmailRecipient = builder.Configuration["EmailRecipient"]
});

builder.Services.AddScoped(x =>
{
    return new SmtpClient()
    {
        Host = builder.Configuration["EmailHost"],
        Port = Convert.ToInt32(builder.Configuration["EmailPort"]),
        Credentials = new NetworkCredential(builder.Configuration["EmailUsername"], builder.Configuration["EmailPassword"]),
        EnableSsl = true,
        UseDefaultCredentials = false,
        DeliveryMethod = SmtpDeliveryMethod.Network
    };
}
);

builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddDbContext<IWeddingEntities, WeddingEntities>(options => options.UseSqlServer(@builder.Configuration["DataSource"]));
builder.Services.AddTransient<IWeddingService, WeddingService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();