using FIT_Api_Example.Data;
using FIT_Api_Example.Helper.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

using Microsoft.Extensions.Configuration;


var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("db1")));

/*
builder.Services.AddDbContext<LogDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("dbLog")));
*/


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x=>x.OperationFilter<AutorizacijaSwaggerHeader>());
//builder.Services.AddTransient<MyAuthService>();
builder.Services.AddTransient<MyEmailSenderService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())//ovaj if iskljucuje swagger nakon deploya na app.fit.ba
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors(
    options => options
        .SetIsOriginAllowed(x => _ = true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
); //This needs to set everything allowed


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
