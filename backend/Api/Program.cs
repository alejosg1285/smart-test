using Application;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.LogTo(Console.Write, new [] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information).EnableSensitiveDataLogging();
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDb"));
});

builder.Services.AddMediatR(_ => _.RegisterServicesFromAssembly(typeof(CreateHotelCommand).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(HotelValidator).Assembly);
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

var config = builder.Configuration.GetSection("Mailing");
builder.Services.AddFluentEmail(config["username"])
    .AddSmtpSender(config["host"], int.Parse(config["port"]!), config["email"], config["password"]);
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
