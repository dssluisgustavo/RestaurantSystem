using Domain.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.Context;
using System.Data.Common;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

DB_Settings.ConnectionString = Environment.GetEnvironmentVariable("DB_Restaurant");
JWT_Settings.Secret = Environment.GetEnvironmentVariable("JWT_Secret");

// Add services to the container.

builder.Services.AddControllers();

byte[] key = Encoding.ASCII.GetBytes(JWT_Settings.Secret);

builder.Services.AddAuthentication(authentic =>
{
    authentic.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authentic.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    
}).AddJwtBearer(jwt =>
{
    jwt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
