using WebSolutionSelf.WebApp._2_Services.ServicesInterface;
using WebSolutionSelf.WebApp._2_Services.ServiceLogic;
using WebSolutionSelf.WebApp._3_BusinessLogic.ICarBusinessLogic;
using WebSolutionSelf.WebApp._3_BusinessLogic.CarBusinessLogic;
using WebSolutionSelf.WebApp._4_DataAccess.CarRepository;
using WebSolutionSelf.WebApp._4_DataAccess.ICarRepository;
using WebSolutionSelf.WebApp._4_DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<ICarServices , CarServices>();
builder.Services.AddTransient<ICarBusinessLogic1, CarBusinessLogic1>();
builder.Services.AddTransient<ICarRepositor, CarRepositor1>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(x => x.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.36
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
