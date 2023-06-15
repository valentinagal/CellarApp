
using Microsoft.AspNetCore.Http.Json;
using WineCellar.API.Data;
using WineCellar.API.Data;
using WineCellar.API.EndPoints;
using WineCellar.API.Repository;

namespace WineCellar.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ICellarRepository, CellarRepository>();
            builder.Services.AddDbContext<WineCellarContext>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<JsonOptions>(o => {
                o.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles; 
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<WineCellarContext>();
                DbInitializer.Initialize(context);
            }

            app.ConfigureWineAPI();
            app.ConfigureUserAPI();
            app.ConfigureTagAPI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}