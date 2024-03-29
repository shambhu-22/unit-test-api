using Crud2.Models;
using Crud2.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// SHOW TIME STARTS
// Add SQL 
var sqlConnBuilder = new SqlConnectionStringBuilder();
sqlConnBuilder.ConnectionString = builder.Configuration.GetConnectionString("IceCreamDBConnectionString");
//Register DbContext
builder.Services.AddDbContext<IceCreamContext>(optionsAction => optionsAction.UseSqlServer(sqlConnBuilder.ConnectionString));
// Register Repositories
builder.Services.AddScoped<IIceCreamRepository, IceCreamRepository>();
// SHOW TIME ENDS





var app = builder.Build();
app.UseCors(y => y.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
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
