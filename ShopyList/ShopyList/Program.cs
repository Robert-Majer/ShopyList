using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopyList.ApplicationServices.API.Domain;
using ShopyList.ApplicationServices.Mappings;
using ShopyList.DataAccess;
using ShopyList.DataAccess.CQRS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();

builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();

builder.Services.AddAutoMapper(typeof(ProductsProfile).Assembly);

builder.Services.AddMediatR(typeof(ResponseBase<>));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddControllers();

builder.Services.AddDbContext<ShopyListStorageContext>(opt => opt.UseSqlServer("name=ConnectionStrings:ShopyListDatabaseConnetcion"));

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