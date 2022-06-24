using Microsoft.EntityFrameworkCore;
using CoYBackend.Models;
using CoYBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IMoneyRepo, MoneyRepo>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
builder.Services.AddDbContext<CoYBackendContext>(options => options.UseMySql(connectionString, serverVersion));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
  app.Urls.Add("http://*:5000");
}

app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            //.WithOrigins("https://localhost:44351/%22)); // Allow only this origin can also have multiple origins seperated with comma
            .SetIsOriginAllowed(origin => true));// Allow any origin

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();