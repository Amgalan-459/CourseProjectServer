
using CourseProjectServer.Controllers;
using CourseProjectServer.Data.Context;

namespace CourseProjectServer {
    public class Program {
        public static void Main (string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<EntetiesController>();
            builder.Services.AddDbContext<CourseDbContext>();

            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
                    .AllowCredentials());

            app.UseAuthorization();


            app.MapGet("/api/trainee/all", (EntetiesController userController) =>
                userController.GetAllTrainees());
            app.MapGet("/api/trainee/{id: int}", (EntetiesController userController, int id) =>
                userController.GetTrainee(id));


            app.Run();
        }
    }
}
