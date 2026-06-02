using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Practical_26.Application.Interfaces.Repository;
using Practical_26.Application.Interfaces.Service;
using Practical_26.Application.Mapping;
using Practical_26.Application.Validator;
using Practical_26.DAL.Data;
using Practical_26.DAL.Repositories;

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
builder.Services.AddScoped(typeof(IGenericCommandRepository<>), typeof(GenericCommandRepository<>));
builder.Services.AddScoped(typeof(IGenericQueryRepository<>), typeof(GenericQueryRepository<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IEmployeeCommandService, EmployeeCommandService>();
builder.Services.AddScoped<IEmployeeQueryService, EmployeeQueryService>();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateValidator>();

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
