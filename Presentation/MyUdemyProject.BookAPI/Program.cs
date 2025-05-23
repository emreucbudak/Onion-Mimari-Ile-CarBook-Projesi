using MyUdemyProject.Application.Features.CQRS.Handler.AboutHandlers;
using MyUdemyProject.Application.Features.CQRS.Queries.AboutQueries;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.BookAPI.Extensions;
using MyUdemyProject.Persistence.ApplicationDbContext;
using MyUdemyProject.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext();
builder.Services.AddAboutCqrs();
builder.Services.AddRepository();
builder.Services.AddBannerCqrs();
builder.Services.AddBrandCqrs();
builder.Services.AddCarsCqrs();

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
