using Microsoft.EntityFrameworkCore;
using CoYBackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CoYBackendContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();
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
