using crud_net_6.Data.Interfaces;
using crud_net_6.Data.Repositories;
using crud_net_6.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("CrudNet6Context");

builder.Services.AddDbContext<CrudNet6Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddCors();

builder.Services.AddScoped<IStudent<TblStudent>, StudentRepository>();

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
