using CourseProjectServer.Data.Context;
using CourseProjectServer.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseProjectServer.Controllers { //потом добавить проверку по jwt токену, а потм и на posgtresql
    public class EntetiesController : Controller {
        private readonly ILogger<EntetiesController> _logger;
        private CourseDbContext dbContext;

        public EntetiesController (ILogger<EntetiesController> logger, CourseDbContext dbContext) {
            _logger = logger;
            this.dbContext = dbContext;
        }


        //дописать Exercise, ExerciseRaw
        #region Get
        internal async Task<IEnumerable<Trainee>> GetAllTrainees () {
            _logger.LogInformation("trainee get all");
            
            return await dbContext.Trainees.ToArrayAsync();
        }

        internal async Task<IEnumerable<Trainer>> GetAllTrainers () {
            _logger.LogInformation("trainer get all");

            return await dbContext.Trainers.ToArrayAsync();
        }

        internal async Task<IEnumerable<Workout>> GetAllWorkouts () {
            _logger.LogInformation("workout get all");

            return await dbContext.Workouts.ToArrayAsync();
        }

        internal async Task<IEnumerable<ExerciseRaw>> GetAllExerciseRaw () {
            _logger.LogInformation("exercise raw get all");

            return await dbContext.ExerciseRaws.ToArrayAsync();
        }

        internal async Task<Trainee> GetTrainee (int id) {
            _logger.LogInformation($"trainee get {id}");

            return await dbContext.Trainees.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        internal async Task<Trainer> GetTrainer (int id) {
            _logger.LogInformation($"trainer get {id}");

            return await dbContext.Trainers.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        internal async Task<Workout> GetWorkout (int id) {
            _logger.LogInformation($"workout get {id}");

            return await dbContext.Workouts.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        internal async Task<ExerciseRaw> GetExerciseRaw (int id) {
            _logger.LogInformation($"exercise raw get {id}");

            return await dbContext.ExerciseRaws.Where(t => t.Id == id).FirstOrDefaultAsync();
        }
        #endregion


        #region Post
        internal async Task<IResult> AddTrainee (Trainee trainee) {
            _logger.LogInformation("trainee post");

            if (dbContext.Trainees.Contains(trainee)) {
                dbContext.Trainees.Update(trainee);
            }
            else {
                await dbContext.Trainees.AddAsync(trainee);
            }

            await dbContext.SaveChangesAsync();
            return TypedResults.Ok( trainee );
        }

        internal async Task<IResult> AddTrainer (Trainer trainer) {
            _logger.LogInformation("trainer post");

            if (dbContext.Trainers.Contains(trainer)) {
                dbContext.Trainers.Update(trainer);
            }
            else {
                await dbContext.Trainers.AddAsync(trainer);
            }

            await dbContext.SaveChangesAsync();
            return TypedResults.Ok( trainer );
        }

        internal async Task<IResult> AddWorkout (Workout workout) {
            _logger.LogInformation("workout post");

            if (dbContext.Workouts.Contains(workout)) {
                dbContext.Workouts.Update(workout);
            }
            else {
                await dbContext.Workouts.AddAsync(workout);
            }

            await dbContext.SaveChangesAsync();
            return TypedResults.Ok( workout );
        }

        internal async Task<IResult> AddExerciseRaw (ExerciseRaw exerciseRaw) {
            _logger.LogInformation("exercise raw post");

            if (dbContext.ExerciseRaws.Contains(exerciseRaw)) {
                dbContext.ExerciseRaws.Update(exerciseRaw);
            }
            else {
                await dbContext.ExerciseRaws.AddAsync(exerciseRaw);
            }

            await dbContext.SaveChangesAsync();
            return TypedResults.Ok(exerciseRaw);
        }
        #endregion


        #region Delete
        internal async Task<IResult> DeleteTrainee (int id) {
            _logger.LogInformation("trainee delete");
            Trainee? trainee = await dbContext.Trainees
                .FirstOrDefaultAsync();
            if (trainee is null) {
                _logger.LogInformation("trainee not found");
                return TypedResults.NotFound($"Trainee с ID = {id} не найден");
            }
            return TypedResults.Ok( dbContext.Trainees.Remove(trainee) );
        }

        internal async Task<IResult> DeleteTrainer (int id) {
            _logger.LogInformation("trainer delete");
            Trainer? trainer = await dbContext.Trainers
                .FirstOrDefaultAsync();
            if (trainer is null) {
                _logger.LogInformation("trainer not found");
                return TypedResults.NotFound($"Trainer с ID = {id} не найден");
            }
            return TypedResults.Ok( dbContext.Trainers.Remove(trainer) );
        }

        internal async Task<IResult> DeleteWorkout (int id) {
            _logger.LogInformation("workout delete");
            Workout? workout = await dbContext.Workouts
                .FirstOrDefaultAsync();
            if (workout is null) {
                _logger.LogInformation("workout not found");
                return TypedResults.NotFound($"Workout с ID = {id} не найден");
            }
            return TypedResults.Ok (dbContext.Workouts.Remove(workout) );
        }
        #endregion
    }
}
