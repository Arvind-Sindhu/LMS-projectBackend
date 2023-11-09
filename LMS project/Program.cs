using DomainLayer.Data;
using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepo;
using RepositoryLayer.Repo;
using ServiceLayer.IService;
using ServiceLayer.Service;

var builder = WebApplication.CreateBuilder(args);
var ConnectionString = builder.Configuration.GetConnectionString("MyDb");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));


// Add services to the container.
builder.Services.AddScoped<IApplyLeaveService<ApplyLeave>, ApplyLeaveService>();
builder.Services.AddScoped<IApplyLeaveRepo<ApplyLeave>, ApplyLeaveRepo<ApplyLeave>>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI()
 ;
}

// Allow CORS using the default policy
app.UseCors();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
