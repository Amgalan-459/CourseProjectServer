
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
                    webBuilder.UseUrls("http://192.168.1.64:5000/");
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
                endpoints.MapGet("/api/trainee/all", (EntetiesController controller) =>
                    controller.GetAllTrainees());
                endpoints.MapGet("/api/trainee/{id:int}", (EntetiesController controller, int id) =>
                    controller.GetTrainee(id));
                endpoints.MapGet("/api/trainee/{email}", (EntetiesController controller, string email) =>
                    controller.GetTraineeByEmail(email));
                endpoints.MapGet("/api/trainee/trainer/{id:int}", (EntetiesController controller, int id) =>
                    controller.GetTraineesByTrainerId(id));

                //потом смотрим от кого. Если от тренера или админа - пароль надо, а если нет, то нет
                endpoints.MapGet("/api/trainer/all", (EntetiesController controller) =>
                    controller.GetAllTrainers());
                endpoints.MapGet("/api/trainer/{id:int}", (EntetiesController controller, int id) =>
                    controller.GetTrainer(id));
                endpoints.MapGet("/api/trainer/{email}", (EntetiesController controller, string email) =>
                    controller.GetTrainerByEmail(email));

                endpoints.MapGet("/api/workout/all", (EntetiesController controller) =>
                    controller.GetAllWorkouts());
                endpoints.MapGet("/api/workout/{id:int}", (EntetiesController controller, int id) =>
                    controller.GetWorkout(id));
                endpoints.MapGet("/api/workout/trainee/{id:int}", (EntetiesController controller, int id) =>
                    controller.GetWorkoutsByTraineeId(id));

                endpoints.MapGet("/api/exercise/all", (EntetiesController controller) =>
                    controller.GetAllExercises());
                endpoints.MapGet("/api/exercise/{id:int}", (EntetiesController controller, int id) =>
                    controller.GetExercise(id));
                endpoints.MapGet("/api/exercise/workout/{id:int}", (EntetiesController controller, int id) =>
                    controller.GetExerciseByWorkoutId(id));

                endpoints.MapGet("/api/exerciseraw/all", (EntetiesController controller) =>
                    controller.GetAllExerciseRaws());
                endpoints.MapGet("/api/exerciseraw/{id:int}", (EntetiesController controller, int id) =>
                    controller.GetExerciseRaw(id));

                endpoints.MapGet("/api/admin/all", (EntetiesController controller) =>
                    controller.GetAllAdminss());
                endpoints.MapGet("/api/admin/{id:int}", (EntetiesController controller, int id) =>
                    controller.GetAdmin(id));
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

                endpoints.MapPost("/api/exercise",
                    (EntetiesController controller, [FromBody] Exercise exercise) =>
                        controller.AddExercise(exercise));

                endpoints.MapPost("/api/exerciseraw",
                    (EntetiesController controller, [FromBody] ExerciseRaw exerciseRaw) =>
                        controller.AddExerciseRaw(exerciseRaw));

                endpoints.MapPost("/api/admin",
                    (EntetiesController controller, [FromBody] Admin admin) =>
                        controller.AddAdmin(admin));
                
                //также для подтверждения email. Еще потом добавить в бд isEmailApproved
                endpoints.MapPost("/api/forgetpassword/{email}",
                    (EntetiesController controller, string email) =>
                        controller.ForgetPasswordT(email));
                #endregion


                //delete не пользуемся, а меняем в юзере или админе настройку IsActive. Delete в основном только к exercise
                #region MapDelete
                endpoints.MapDelete("/api/trainee/{id:int}",
                    (EntetiesController controller, int id) => controller.DeleteTrainee(id));

                endpoints.MapDelete("/api/trainer/{id:int}",
                    (EntetiesController controller, int id) => controller.DeleteTrainer(id));

                endpoints.MapDelete("/api/workout/{id:int}",
                    (EntetiesController controller, int id) => controller.DeleteWorkout(id));

                endpoints.MapDelete("/api/exercise/{id:int}",
                    (EntetiesController controller, int id) => controller.DeleteExercise(id));

                endpoints.MapDelete("/api/exerciseraw/{id:int}",
                    (EntetiesController controller, int id) => controller.DeleteExerciseRaw(id));

                endpoints.MapDelete("/api/admin/{id:int}",
                    (EntetiesController controller, int id) => controller.DeleteAdmin(id));
                #endregion
            });
        }
    }
}
