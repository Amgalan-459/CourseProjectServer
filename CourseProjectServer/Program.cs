
using CourseProjectServer.Controllers;
using CourseProjectServer.Data.Context;
using CourseProjectServer.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CourseProjectServer {
    public class Program {
        public static async Task Main (string[] args) {       
            await CreateHostBuiler(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuiler (string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseKestrel();
                    webBuilder.UseUrls("http://192.168.1.72:3000/");
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class Startup {
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<EntetiesController>();
            services.AddDbContext<CourseDbContext>();

            services.AddCors();
        }

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseRouting();
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment()) {
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

            app.UseEndpoints(endpoints => {

                #region MapGet
                endpoints.MapGet("/api/trainee/all", (EntetiesController userController) =>
                    userController.GetAllTrainees());
                endpoints.MapGet("/api/trainee/{id:int}", (EntetiesController userController, int id) =>
                    userController.GetTrainee(id));

                endpoints.MapGet("/api/trainer/all", (EntetiesController userController) =>
                    userController.GetAllTrainers());
                endpoints.MapGet("/api/trainer/{id:int}", (EntetiesController userController, int id) =>
                    userController.GetTrainer(id));

                endpoints.MapGet("/api/workout/all", (EntetiesController userController) =>
                    userController.GetAllWorkouts());
                endpoints.MapGet("/api/workout/{id:int}", (EntetiesController userController, int id) =>
                    userController.GetWorkout(id));
                #endregion


                #region MapPost
                endpoints.MapPost("/api/trainee",
                    (EntetiesController controller, [FromBody] Trainee trainee) =>
                        controller.AddTrainee(trainee));

                endpoints.MapPost("/api/trainer",
                    (EntetiesController controller, [FromBody] Trainer trainer) =>
                        controller.AddTrainer(trainer));

                endpoints.MapPost("/api/workout",
                    (EntetiesController controller, [FromBody] Workout workout) =>
                        controller.AddWorkout(workout));
                #endregion


                #region MapDelete
                endpoints.MapDelete("/api/trainee/{id:int}",
                    (EntetiesController controller, int id) => controller.DeleteTrainee(id));

                endpoints.MapDelete("/api/trainer/{id:int}",
                    (EntetiesController controller, int id) => controller.DeleteTrainer(id));

                endpoints.MapDelete("/api/workout/{id:int}",
                    (EntetiesController controller, int id) => controller.DeleteWorkout(id));
                #endregion


                #region MapUpdate
                endpoints.MapPut("/api/trainee/{id:int}",
                    (EntetiesController controller, int id) =>
                    controller.UpdateTrainee(id));
                #endregion
            });
        }
    }
}
