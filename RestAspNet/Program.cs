using Microsoft.EntityFrameworkCore;
using RestAspNet.Model.Context;
using RestAspNet.Business;
using RestAspNet.Business.Implementations;   
using RestAspNet.Repository.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// api versioning
builder.Services.AddApiVersioning();

var connection = builder.Configuration["MysqlConnection:MySqlConnectionString"];

// Dependency Injection
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0))));

builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>(); 
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();
 
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

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