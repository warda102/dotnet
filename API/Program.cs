using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistance.data;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
// Add services to the container.

 static DbConnectionInfo GetConnectionInfo(IConfiguration configuration)
{
    DbConnectionInfo dbConnectionInfo;

    if (Environment.OSVersion.Platform == PlatformID.Unix)
    {
        dbConnectionInfo = new()
        {
            Host = Environment.GetEnvironmentVariable("PG_HOST"),
            Database = Environment.GetEnvironmentVariable("PG_DATABASE"),
            Username = Environment.GetEnvironmentVariable("PG_USERNAME"),
            Password = Environment.GetEnvironmentVariable("PG_PASSWORD")
        };
    }
    else
    {
        dbConnectionInfo = new()
        {
            Host = configuration.GetValue<string>("DataConnection:Hostname"),
            Database = configuration.GetValue<string>("DataConnection:Database"),
            Username = configuration.GetValue<string>("DataConnection:Username"),
            Password = configuration.GetValue<string>("DataConnection:Password")
        };
    }

    return dbConnectionInfo;
}
builder.Services.AddDbContext<EmployeeContext>(options => options.UseNpgsql(GetConnectionInfo(configuration).ToString()).EnableSensitiveDataLogging());
builder.Services.AddScoped<IEmployeeContext, EmployeeContext>();
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
