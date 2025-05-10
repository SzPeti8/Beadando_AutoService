
using AutoService.Api;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSerilog(
    options => options
        .MinimumLevel.Information()
        .WriteTo.Console());

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(
    options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
        options.UseLazyLoadingProxies();
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IWorkService, WorkService>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
