using DocumentDetails;
using DocumentDetails.DTOs;
using DocumentDetails.Repositories;
using DocumentDetails.Services;
using DocumentDetails.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AuthenticationConfiguration>(builder.Configuration.GetSection("Authentication"));


// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<DocumentDetailsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<DocumentRepository>();
builder.Services.AddTransient<DocumentService>();
builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<BCryptPasswordHasher>();
builder.Services.AddTransient<Authenticator>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:AccessTokenSecret"])),
        ValidIssuer = builder.Configuration["Authentication:Audience"],
        ValidAudience = builder.Configuration["Authentication:Issuer"],
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
