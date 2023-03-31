global using Microsoft.EntityFrameworkCore;
global using Server.Data;
global using Server.Repositories;
global using Server.Services;
global using Server.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Server.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            )
        };
        o.SecurityTokenValidators.Clear();
        o.SecurityTokenValidators.Add(new SecurityTokenValidator());
    });

builder.Services
// .AddEntityFrameworkNpgsql()
.AddDbContext<DataContext>(opt => opt.UseNpgsql(builder.Configuration["ConnectionString"]));
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<ISecurityTokenValidator, SecurityTokenValidator>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<UserProfileService>();
builder.Services.AddScoped<UserProfileRepository>();
builder.Services.AddScoped<AgencyService>();
builder.Services.AddScoped<AgencyRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
