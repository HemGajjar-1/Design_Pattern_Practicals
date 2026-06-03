using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Practical_22.Application.Interfaces;
using Practical_22.Application.Interfaces.Repositories;
using Practical_22.Application.Interfaces.UnitOfWork;
using Practical_22.Application.Mapping;
using Practical_22.Application.Validators;
using Practical_22.Infrastructure.Data;
using Practical_22.Infrastructure.Logging;
using Practical_22.Infrastructure.Repositories;
using Practical_22.Infrastructure.Services;
using Practical_22.Infrastructure.UnitOfWork;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSingleton<ILoggerService>(LoggerService.Instance);
builder.Services.AddScoped<IEmployeeService,EmployeeService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(EmployeeProfile));

builder.Services
    .AddFluentValidationAutoValidation();

builder.Services
    .AddValidatorsFromAssemblyContaining<
        CreateEmployeeValidator>();

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
