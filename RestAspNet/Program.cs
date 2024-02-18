using Microsoft.EntityFrameworkCore;
using RestAspNet.Model.Context;
using RestAspNet.Business;
using RestAspNet.Business.Implementations;   
using RestAspNet.Repository.Generic;
using Microsoft.Net.Http.Headers;
using RestAspNet.Data.VO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// api versioning
builder.Services.AddApiVersioning();

var connection = builder.Configuration["MysqlConnection:MySqlConnectionString"];

builder.Services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true; // false by default
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
    options.FormatterMappings.SetMediaTypeMappingForFormat("json+hateoas", MediaTypeHeaderValue.Parse("application/json+hateoas"));
}).AddXmlSerializerFormatters();


//HATEOAS (Fazer isso aqui funcionar)
//builder.Services.AddMvc().AddHateoas(options =>
//{ 
//    options.AddLink<PersonVO>("get-person", p => new { id = p.id });
//    options.AddLink<List<PersonVO>>("create-person");
//    options.AddLink<PersonVO>("update-person", p => new { id = p.id });
//    options.AddLink<PersonVO>("delete-person", p => new { id = p.id });
//});

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