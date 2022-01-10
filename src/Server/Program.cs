using AllisonOwenWedding.DataAccess;
using AllisonOwenWedding.Services;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
builder.Services.AddDbContext<IWeddingEntities, WeddingEntities>(options => options.UseSqlServer(builder.Configuration["DataSource"]));
builder.Services.AddTransient<IWeddingService, WeddingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
