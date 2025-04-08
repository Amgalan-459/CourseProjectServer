
using CourseProjectServer.Controllers;
using CourseProjectServer.Data.Context;
using CourseProjectServer.Data.Entities;
using Microsoft.AspNetCore.Mvc;

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

            #region MapGet
            app.MapGet("/api/trainee/all", (EntetiesController userController) =>
                userController.GetAllTrainees());
            app.MapGet("/api/trainee/{id:int}", (EntetiesController userController, int id) =>
                userController.GetTrainee(id));

            app.MapGet("/api/trainer/all", (EntetiesController userController) =>
                userController.GetAllTrainers());
            app.MapGet("/api/trainer/{id:int}", (EntetiesController userController, int id) =>
                userController.GetTrainer(id));

            app.MapGet("/api/workout/all", (EntetiesController userController) =>
                userController.GetAllWorkouts());
            app.MapGet("/api/workout/{id:int}", (EntetiesController userController, int id) =>
                userController.GetWorkout(id));
            #endregion


            #region MapPost
            app.MapPost("/api/trainee",
                (EntetiesController controller, [FromBody] Trainee trainee) =>
                    controller.AddTrainee(trainee));

            app.MapPost("/api/trainer",
                (EntetiesController controller, [FromBody] Trainer trainer) =>
                    controller.AddTrainer(trainer));

            app.MapPost("/api/workout",
                (EntetiesController controller, [FromBody] Workout workout) =>
                    controller.AddWorkout(workout));
            #endregion


            #region MapDelete
            app.MapDelete("/api/trainee/{id:int}",
                (EntetiesController controller, int id) => controller.DeleteTrainee(id));

            app.MapDelete("/api/trainer/{id:int}",
                (EntetiesController controller, int id) => controller.DeleteTrainer(id));

            app.MapDelete("/api/workout/{id:int}",
                (EntetiesController controller, int id) => controller.DeleteWorkout(id));
            #endregion


            #region MapUpdate
            app.MapPut("/api/trainee/{id:int}",
                (EntetiesController controller, int id) =>
                controller.UpdateTrainee(id));
            #endregion

            app.Run();
        }
    }
}
