using Infrastructure;
using Application;
using Microsoft.EntityFrameworkCore;
using StarSecurityAPI.Data;
using System.Reflection;
using MediatR;
using Application.Contracts.Persistences.Common;
using Application.Contracts.Persistences;
using Infrastructure.Repositories.Common;
using Infrastructure.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.ConfigurationApplicationServices()
	.ConfigureInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o =>
{
	o.AddPolicy("CorsPolicy",
		builder => builder.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
