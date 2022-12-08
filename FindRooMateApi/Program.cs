using FindRooMateApi.BLL.Services.Implementation;
using FindRooMateApi.BLL.Services.Interface;
using FindRooMateApi.DAL.Context;
using FindRooMateApi.DAL.Repositories.Implementations;
using FindRooMateApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add database dependecy
_ = builder.Services.AddDbContext<FindRooMateContext>(c =>
{
    c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    c.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});

// add dependecy injection for classes and interfaces
//kshu duhet ber per cdo rast, qe te funksionoj cit.
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IDormitoryRepository, DormitoryRepository>();
builder.Services.AddScoped<IDormitoryService, DormitoryService>();

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
