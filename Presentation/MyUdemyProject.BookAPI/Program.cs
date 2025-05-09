using MyUdemyProject.Application.Features.CQRS.Handler.AboutHandlers;
using MyUdemyProject.Application.Features.CQRS.Queries.AboutQueries;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.Persistence.ApplicationDbContext;
using MyUdemyProject.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CarBookDbContext>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<AddAboutQueryHandler>();
builder.Services.AddScoped<RemoveAboutQueryHandler>();
builder.Services.AddScoped<UpdateAboutQueryHandler>();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

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
