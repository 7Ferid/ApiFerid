using ApiFerid.Api.Middlewares;
using ApiFerid.Business.ServiceRegistrations;
using ApiFerid.DataAccess.ServiceRegistrations;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    //builder.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
           .AllowAnyHeader();
}));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBusinessServices();
builder.Services.AddDataAccessServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseCors("MyPolicy");

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
