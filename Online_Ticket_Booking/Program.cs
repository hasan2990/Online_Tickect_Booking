using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Online_Ticket_Booking.Models.Data;
using Online_Ticket_Booking.Repositories.Implemantations;
using Online_Ticket_Booking.Repositories.Implementations;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Implemantations;
using Online_Ticket_Booking.Services.Implementations;
using Online_Ticket_Booking.Services.Interfaces;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var builder = WebApplication.CreateBuilder(args);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("q5WfZ7vfNkyDq6gYhTsW2vGxXKnRE2Py"))
        };
    });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IRegistrationRepo, RegistrationRepo>();
builder.Services.AddTransient<IRegistrationService, RegistrationService>();
builder.Services.AddTransient<ILoginRepo, LoginRepo>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IBusRepo, BusRepo>();
builder.Services.AddTransient<IBusService, BusService>();
builder.Services.AddTransient<IRoadRepo, RoadRepo>();
builder.Services.AddTransient<IRoadService, RoadService>();
builder.Services.AddTransient<IGetBusesRepo, GetBusesRepo>();
builder.Services.AddTransient<IGetBusesService, GetBusesService>();
builder.Services.AddTransient<IBookingRepo, BookingRepo>();
builder.Services.AddTransient<IBookingService, BookingService>();
builder.Services.AddTransient<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();

app.MapControllers();

app.Run();
