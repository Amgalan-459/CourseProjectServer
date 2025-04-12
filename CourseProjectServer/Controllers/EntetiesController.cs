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

        internal async Task<IEnumerable<ExerciseRaw>> GetAllExerciseRaws () {
            _logger.LogInformation("exercise raw get all");

            return await dbContext.ExerciseRaws.ToArrayAsync();
        }

        internal async Task<IEnumerable<Exercise>> GetAllExercises () {
            _logger.LogInformation("exercise get all");

            return await dbContext.Exercises.ToArrayAsync();
        }

        internal async Task<IEnumerable<Admin>> GetAllAdminss () {
            _logger.LogInformation("admin get all");

            return await dbContext.Admins.ToArrayAsync();
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

        internal async Task<Exercise> GetExercise (int id) {
            _logger.LogInformation($"exercise get {id}");

            return await dbContext.Exercises.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        internal async Task<Admin> GetAdmin (int id) {
            _logger.LogInformation($"admin get {id}");

            return await dbContext.Admins.Where(t => t.Id == id).FirstOrDefaultAsync();
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

        internal async Task<IResult> AddExercise (Exercise exercise) {
            _logger.LogInformation("exercise post");

            if (dbContext.Exercises.Contains(exercise)) {
                dbContext.Exercises.Update(exercise);
            }
            else {
                await dbContext.Exercises.AddAsync(exercise);
            }

            await dbContext.SaveChangesAsync();
            return TypedResults.Ok(exercise);
        }

        internal async Task<IResult> AddAdmin (Admin admin) {
            _logger.LogInformation("admin post");

            if (dbContext.Admins.Contains(admin)) {
                dbContext.Admins.Update(admin);
            }
            else {
                await dbContext.Admins.AddAsync(admin);
            }

            await dbContext.SaveChangesAsync();
            return TypedResults.Ok(admin);
        }
        #endregion


        #region Delete
        internal async Task<IResult> DeleteTrainee (int id) {
            _logger.LogInformation("trainee delete");
            Trainee? trainee = await dbContext.Trainees.Where(t => t.Id == id)
                .FirstOrDefaultAsync();
            if (trainee is null) {
                _logger.LogInformation("trainee not found");
                return TypedResults.NotFound($"Trainee с ID = {id} не найден");
            }
            dbContext.Trainees.Remove(trainee);

            await dbContext.SaveChangesAsync();
            return TypedResults.Ok();
        }

        internal async Task<IResult> DeleteTrainer (int id) {
            _logger.LogInformation("trainer delete");
            Trainer? trainer = await dbContext.Trainers.Where(t => t.Id == id)
                .FirstOrDefaultAsync();
            if (trainer is null) {
                _logger.LogInformation("trainer not found");
                return TypedResults.NotFound($"Trainer с ID = {id} не найден");
            }
            dbContext.Trainers.Remove(trainer);

            await dbContext.SaveChangesAsync();
            return TypedResults.Ok();
        }

        internal async Task<IResult> DeleteWorkout (int id) {
            _logger.LogInformation("workout delete");
            Workout? workout = await dbContext.Workouts.Where(w => w.Id == id)
                .FirstOrDefaultAsync();
            if (workout is null) {
                _logger.LogInformation("workout not found");
                return TypedResults.NotFound($"Workout с ID = {id} не найден");
            }
            dbContext.Workouts.Remove(workout);

            await dbContext.SaveChangesAsync();
            return TypedResults.Ok ();
        }

        internal async Task<IResult> DeleteExerciseRaw (int id) {
            _logger.LogInformation("exercise raw delete");
            ExerciseRaw? exerciseRaw = await dbContext.ExerciseRaws.Where(e => e.Id == id)
                .FirstOrDefaultAsync();
            if (exerciseRaw is null) {
                _logger.LogInformation("exercise raw not found");
                return TypedResults.NotFound($"Exercise raw с ID = {id} не найден");
            }
            dbContext.ExerciseRaws.Remove(exerciseRaw);

            await dbContext.SaveChangesAsync();
            return TypedResults.Ok();
        }

        internal async Task<IResult> DeleteExercise (int id) {
            _logger.LogInformation("exercise delete");
            Exercise? exercise = await dbContext.Exercises.Where(e => e.Id == id)
                .FirstOrDefaultAsync();
            if (exercise is null) {
                _logger.LogInformation("exercise not found");
                return TypedResults.NotFound($"Exercise с ID = {id} не найден");
            }
            dbContext.Exercises.Remove(exercise);

            await dbContext.SaveChangesAsync();
            return TypedResults.Ok();
        }

        internal async Task<IResult> DeleteAdmin (int id) {
            _logger.LogInformation("admin delete");
            Admin? admin = await dbContext.Admins.Where(a => a.Id == id)
                .FirstOrDefaultAsync();
            if (admin is null) {
                _logger.LogInformation("admin not found");
                return TypedResults.NotFound($"Admin с ID = {id} не найден");
            }
            dbContext.Admins.Remove(admin);

            await dbContext.SaveChangesAsync();
            return TypedResults.Ok();
        }
        #endregion
    }
}
