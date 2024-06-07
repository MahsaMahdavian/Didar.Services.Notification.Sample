using Carter;
using Didar.Services.Notification.Application.Interfaces;
using Didar.Services.Notification.Framework.Extention;
using Didar.Services.Notification.WebApi.Installer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//TODO: builder.Services.AddDbcontext
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.InstallService<ApplicationServiceInstaller>();
builder.InstallService<InfrastructureInstaller>();
builder.Services.AddCarter();
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

app.MapCarter();
app.Run();
