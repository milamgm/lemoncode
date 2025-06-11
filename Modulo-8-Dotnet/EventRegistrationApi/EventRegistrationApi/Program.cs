using EventRegistrationApi.Api.Extensions;
using FluentValidation;

using EventRegistrationApi.Application.Dtos.Queries.Participants;
using EventRegistrationApi.Application.Validators.Participants;
using EventRegistrationApi.DataAccess.Context;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<EventRegistrationApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddMappings()
    .AddConfigurations(builder.Configuration)
    .AddInfraServices()
    .AddAppServices()
    .AddValidatorsFromAssemblyContaining<ParticipantValidator>()
    .AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

