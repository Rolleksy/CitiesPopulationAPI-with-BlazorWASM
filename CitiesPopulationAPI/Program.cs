using DataAccess.DbAccess;

namespace CitiesPopulationAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        builder.Services.AddSingleton<ICitiesPopData, CitiesPopData>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "AllowBlazorOrigin",
                builder =>
                {
                    builder.WithOrigins("https://localhost:7293", "http://localhost:5144");
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
        }
            );

        

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowBlazorOrigin");
       

        app.UseAuthorization();

        app.ConfigureApi();

        app.Run();
    }
}