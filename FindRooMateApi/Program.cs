using FindRooMateApi.BLL.Services.Implementation;
using FindRooMateApi.BLL.Services.Interface;
using FindRooMateApi.DAL.Context;
using FindRooMateApi.DAL.Repositories.Implementations;
using FindRooMateApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

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
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();


// per zgjidhjen e problemeve me api

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseCors("EnableCORS");

app.MapControllers();

app.Run();
