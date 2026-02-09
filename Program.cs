using Microsoft.EntityFrameworkCore;
using Transport_Management_Systems_Portal_REST_API.Data;
using Transport_Management_Systems_Portal_REST_API.Data.Interfaces;
using Transport_Management_Systems_Portal_REST_API.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TMSDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("BaseConnection"), new MySqlServerVersion(new Version(8, 0, 0))));

builder.Services.AddScoped<IAuthenticationRepo, AuthenticationRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


