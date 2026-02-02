using ApiFerid.Api.Middlewares;
using ApiFerid.Business.ServiceRegistrations;
using ApiFerid.DataAccess.Abstractions;
using ApiFerid.DataAccess.ServiceRegistrations;



public partial class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
        {
            //builder.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
                   .AllowAnyHeader();
        }));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDataAccessServices(builder.Configuration); 
        builder.Services.AddBusinessServices(builder.Configuration);

        var app = builder.Build();

        var scope = app.Services.CreateScope();
        var initalizer = scope.ServiceProvider.GetRequiredService<IContextInitalizer>();
        await initalizer.InitDatabaseAsync();
        if (!app.Environment.IsDevelopment())
            app.UseMiddleware<GlobalExceptionHandler>();

        app.UseCors("MyPolicy");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();
    }
}
